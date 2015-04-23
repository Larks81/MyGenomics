angular.module('MyGenomicsApp')
.controller('questionarioController', ['$scope', 'Questionnaire','ContactQuestionnaire','Contact','WizardHandler',
    function ($scope, Questionnaire, ContactQuestionnaire,Contact, WizardHandler) {

        $scope.Questionnaires = null;
        $scope.SelectedQuestionnaire = null;
        $scope.ContactQuestionnaireToFill = null;
        $scope.ContactQuestionnaire = null;
        $scope.TotStep = null;
        $scope.ReadyToLoad = false;
        $scope.ContactErrorText = "";
        $scope.ContactLoginErrorText = "";
        $scope.QuestionnaireFinished = false;
        $scope.ContactQuestionnaireCalculated = false;        

        $scope.Genders = [{
            id: 1,
            label: 'Maschio',            
        }, {
            id: 2,
            label: 'Femmina',            
        }];
       
        $scope.getQuestionnaires = function () {
            var questionnaireDefault = "MYGENOMICS_IT";
            $scope.selectQuestionnaire(questionnaireDefault);                         
        };

        $scope.selectQuestionnaire = function (questionnaireCode) {            
            Questionnaire.get({ code: questionnaireCode }, function (data) {
                $scope.SelectedQuestionnaire = data;
                $scope.buildContactQuestionnaire(data);
            });            
        };

        $scope.buildContactQuestionnaire = function (questionnaire) {
            
            for (var cat = 0; cat < questionnaire.QuestionsCategories.length; cat++) {
                for (var quest = 0; quest < questionnaire.QuestionsCategories[cat].Questions.length; quest++) {
                    for (var answ = 0; answ < questionnaire.QuestionsCategories[cat].Questions[quest].Anwers.length; answ++) {

                        if (questionnaire.QuestionsCategories[cat].Questions[quest].QuestionType == 3) { //ValueOnly
                            questionnaire.QuestionsCategories[cat].Questions[quest].Anwers[answ].SelectedAnswer = true;
                        } else {
                            questionnaire.QuestionsCategories[cat].Questions[quest].Anwers[answ].SelectedAnswer = false;
                        }

                        questionnaire.QuestionsCategories[cat].Questions[quest].Anwers[answ].AdditionalInfo = "";
                        questionnaire.QuestionsCategories[cat].Questions[quest].ErrorText = "";
                    }                    
                }
            }

            $scope.ContactQuestionnaireToFill = questionnaire;
            $scope.TotStep = questionnaire.QuestionsCategories.length;
            $scope.ReadyToLoad = true;            
        };

        $scope.uncheckOthersIfNecessary = function (question,answerId) {

            if (question.QuestionType==1) {
                for (var answ = 0; answ < question.Anwers.length; answ++) {
                    if (question.Anwers[answ].Id != answerId) {
                        question.Anwers[answ].SelectedAnswer = false;
                    }
                }
            }
            

        };

        $scope.submit = function () {

            $scope.QuestionnaireFinished = true;

            var contactQuestionnaire = new ContactQuestionnaire();
            questionnaire = $scope.ContactQuestionnaireToFill;
            contactQuestionnaire.QuestionnaireId = questionnaire.Id;
            
            contactQuestionnaire.ContactId = questionnaire.ContactId;
            contactQuestionnaire.Contact = questionnaire.Contact;
            contactQuestionnaire.Contact.BirthDate = convertToDate(contactQuestionnaire.Contact.BirthDate);
            contactQuestionnaire.GivenAnswers = new Array();
            
            var nQuestion = 0;
            for (var cat = 0; cat < questionnaire.QuestionsCategories.length; cat++) {
                for (var quest = 0; quest < questionnaire.QuestionsCategories[cat].Questions.length; quest++) {
                    for (var answ = 0; answ < questionnaire.QuestionsCategories[cat].Questions[quest].Anwers.length; answ++) {

                        if (questionnaire.QuestionsCategories[cat].Questions[quest].Anwers[answ].SelectedAnswer) {
                            contactQuestionnaire.GivenAnswers[nQuestion] = new Object();
                            contactQuestionnaire.GivenAnswers[nQuestion].QuestionId = questionnaire.QuestionsCategories[cat].Questions[quest].Id;                            
                            contactQuestionnaire.GivenAnswers[nQuestion].AnswerId = questionnaire.QuestionsCategories[cat].Questions[quest].Anwers[answ].Id;
                            contactQuestionnaire.GivenAnswers[nQuestion].AdditionalInfo = questionnaire.QuestionsCategories[cat].Questions[quest].Anwers[answ].AdditionalInfo;
                            nQuestion++;
                        }
                    }
                }
            }

            ContactQuestionnaire.save(contactQuestionnaire).$promise
            .then(function (data) {
                var idInserted = data.idInserted;
                $scope.getQuestionnaireResult(idInserted)
                .then(function(result) {
                    $scope.ContactQuestionnaireResult = result;
                   $scope.ContactQuestionnaireCalculated = true;
                });                
            })
            .catch(function (data) {
                alert("error");
            });                          
        };

        $scope.getQuestionnaireResult = function(id) {
            return ContactQuestionnaire.get({id : id}).$promise;
        };

        $scope.makeLogin = function (username,password) {
            return Contact.login({ username: username, password: password }).$promise;
        };


        $scope.fakeResult = function () {
            $scope.getQuestionnaireResult(2)
                .then(function (result) {
                    $scope.ContactQuestionnaireResult = result;
                    $scope.ContactQuestionnaireCalculated = true;
                });
            $scope.QuestionnaireFinished = true;
        };

        //--------------------------------------------------------------------
        //--------------Validation functions----------------------------------
        //--------------------------------------------------------------------

        $scope.validateAnswers = function (questions) {
            
            var fieldInvalid = 0;
            for (var k = 0; k < questions.length; k++) {
                if (questions[k].IsRequired) {
                    var selectedAnswers = 0;
                    for (var answ = 0 ; answ < questions[k].Anwers.length ; answ++) {
                        if (questions[k].Anwers[answ].SelectedAnswer) {
                            selectedAnswers++;                            
                        }
                    }
                    if (selectedAnswers > 1 && questions[k].QuestionType==1) {
                        questions[k].ErrorText = "* Risposta multipla non consentita";
                        fieldInvalid++;
                    } else if (selectedAnswers < 1 || (questions[k].QuestionType == 3 &&  //ValueOnly
                                                       (typeof (questions[k].Anwers[0].AdditionalInfo) === "undefined" ||
                                                        questions[k].Anwers[0].AdditionalInfo == ""))) {
                        questions[k].ErrorText = "* Risposta necessaria";
                        fieldInvalid++;
                    } else {
                        questions[k].ErrorText = "";
                    }                
                    
                } else {
                    questions[k].ErrorText = "";
                }
            }

            //Check numeric answer
            for (var k = 0; k < questions.length; k++) {                
                for (var answ = 0; answ < questions[k].Anwers.length; answ++) {
                    if (questions[k].Anwers[answ].SelectedAnswer &&
                        typeof (questions[k].Anwers[answ].AdditionalInfo) !== "undefined" &&
                        questions[k].Anwers[answ].AdditionalInfo!="" &&
                        questions[k].Anwers[answ].HasAdditionalInfo &&
                        questions[k].Anwers[answ].AdditionalInfoType == 2) {

                        var value = questions[k].Anwers[answ].AdditionalInfo;
                        var valueMin = questions[k].Anwers[answ].MinValueNumericAdditionalInfo;
                        var valueMax = questions[k].Anwers[answ].MaxValueNumericAdditionalInfo;

                        if (!$.isNumeric(value) || value < valueMin || value > valueMax) {
                            questions[k].ErrorText = "* è necessario inserire un valore numerico da " + valueMin + " a " + valueMax;
                            fieldInvalid++;
                        }
                    }
                }
            }

            if (fieldInvalid == 0) {
                window.scrollTo(0, 0);
                WizardHandler.wizard().next();                
            }            
        };

        
        $scope.validateContact = function (contact) {

            var fieldInvalid = false;
            
            if ((typeof (contact) === "undefined") ||                
                (contact.BirthDate == "" || typeof (contact.BirthDate) === "undefined" ) ||
                (contact.Email == "" || typeof (contact.Email) === "undefined") ||
                (contact.Gender == "" || typeof (contact.Gender) === "undefined"))
            {
                fieldInvalid = true;                
            }
                
            if (!fieldInvalid) {

                if (!contact.PrivacyLawAgree) {
                    $scope.ContactErrorText = "* è necessario acconsentire alla legge sulla privacy";
                } else {

                    if (!validateDate(contact.BirthDate)) {
                        $scope.ContactErrorText = "* formato data non valido formato richiesto 'dd/mm/yyyy'";
                    } else {
                        WizardHandler.wizard().next();
                        window.scrollTo(0, 0);
                        $scope.ContactErrorText = "";
                    }
                }
                
            } else {
                $scope.ContactErrorText = "* è necessario compilare i campi obbligatori";
            }
        };

        $scope.validateLogin = function (contact) {

            var fieldInvalid = false;

            if ((typeof (contact) === "undefined") ||                
                (contact.UserName == "" || typeof (contact.UserName) === "undefined") ||
                (contact.Password == "" || typeof (contact.Password) === "undefined"))                
            {
                fieldInvalid = true;
            }

            if (fieldInvalid == false) {
                $scope.makeLogin(contact.UserName, contact.Password)
                    .then(function (result) {
                        if (result.Id != "" && result.Id > 0) {
                            $scope.ContactQuestionnaireToFill.ContactId = result.Id;
                            $scope.ContactQuestionnaireToFill.Contact = result;
                            $scope.ContactQuestionnaireToFill.Contact.BirthDate = getStringDate($scope.ContactQuestionnaireToFill.Contact.BirthDate);
                            window.scrollTo(0, 0);
                            WizardHandler.wizard().next();                            
                        } else {
                            $scope.ContactLoginErrorText = "* Login non valida!";
                        }
                        
                    }, function (reason) {
                        $scope.ContactLoginErrorText = "* Login non valida!";
                    });
            } else {
                $scope.ContactLoginErrorText = "* Login non valida!";
            }
            
        };

        $scope.continueWithoutLogin = function() {
            WizardHandler.wizard().next();
            window.scrollTo(0, 0);
        };

        function getStringDate(date) {            
            var dateStr = padStr(date.getDate()) + '/' +
                          padStr(1 + date.getMonth()) + '/' +
                          padStr(date.getFullYear());
            return dateStr;
        }

        function padStr(i) {
            return (i < 10) ? "0" + i : "" + i;
        }

        function validateDate(date) 
        {                
            var reg = /(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d/;
            if (date.match(reg)) {
                return true;
            }
            else {                
                return false;
            }
        }
        
        function convertToDate(dateString) {
            var parts = dateString.split("/");
            return new Date(parseInt(parts[2], 10),
                              parseInt(parts[1], 10) - 1,
                              parseInt(parts[0], 10),12,0,0,0);
        }
        

    }]);