angular.module('MyGenomicsApp')
.controller('questionarioController', ['$scope', 'Questionnaire','PersonQuestionnaire','Person','WizardHandler',
    function ($scope, Questionnaire, PersonQuestionnaire,Person, WizardHandler) {

        $scope.Questionnaires = null;
        $scope.SelectedQuestionnaire = null;
        $scope.PersonQuestionnaireToFill = null;
        $scope.PersonQuestionnaire = null;
        $scope.TotStep = null;
        $scope.ReadyToLoad = false;
        $scope.PersonErrorText = "";
        $scope.PersonLoginErrorText = "";
        $scope.QuestionnaireFinished = false;
        $scope.PersonQuestionnaireCalculated = false;        

        $scope.Genders = [{
            id: 1,
            label: 'Maschio',            
        }, {
            id: 2,
            label: 'Femmina',            
        }];
       
        $scope.getQuestionnaires = function () {
            var questionnaireDefault = "MYGENOMICS_IT";
            var questionnaireDefaultId;
            Questionnaire.query( function (data) {
                $scope.Questionnaires = data;

                for (quest = 0; quest < data.length; quest++) {
                    if (data[quest].Code == questionnaireDefault) {
                        questionnaireDefaultId = data[quest].Id;
                    }
                }

                if (questionnaireDefaultId > 0) {
                    $scope.selectQuestionnaire(questionnaireDefaultId);
                }                
            });                        
        };

        $scope.selectQuestionnaire = function (questionnaireId) {            
            Questionnaire.get({ id: questionnaireId }, function (data) {
                $scope.SelectedQuestionnaire = data;
                $scope.buildPersonQuestionnaire(data);
            });            
        };

        $scope.buildPersonQuestionnaire = function (questionnaire) {
            
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

            $scope.PersonQuestionnaireToFill = questionnaire;
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

            var personQuestionnaire = new PersonQuestionnaire();
            questionnaire = $scope.PersonQuestionnaireToFill;
            personQuestionnaire.QuestionnaireId = questionnaire.Id;
            
            personQuestionnaire.PersonId = questionnaire.PersonId;
            personQuestionnaire.Person = questionnaire.Person;
                        
            personQuestionnaire.GivenAnswers = new Array();
            
            var nQuestion = 0;
            for (var cat = 0; cat < questionnaire.QuestionsCategories.length; cat++) {
                for (var quest = 0; quest < questionnaire.QuestionsCategories[cat].Questions.length; quest++) {
                    for (var answ = 0; answ < questionnaire.QuestionsCategories[cat].Questions[quest].Anwers.length; answ++) {

                        if (questionnaire.QuestionsCategories[cat].Questions[quest].Anwers[answ].SelectedAnswer) {
                            personQuestionnaire.GivenAnswers[nQuestion] = new Object();
                            personQuestionnaire.GivenAnswers[nQuestion].QuestionId = questionnaire.QuestionsCategories[cat].Questions[quest].Id;                            
                            personQuestionnaire.GivenAnswers[nQuestion].AnswerId = questionnaire.QuestionsCategories[cat].Questions[quest].Anwers[answ].Id;
                            personQuestionnaire.GivenAnswers[nQuestion].AdditionalInfo = questionnaire.QuestionsCategories[cat].Questions[quest].Anwers[answ].AdditionalInfo;
                            nQuestion++;
                        }
                    }
                }
            }

            PersonQuestionnaire.save(personQuestionnaire).$promise
            .then(function (data) {
                var idInserted = data.idInserted;
                $scope.getQuestionnaireResult(idInserted)
                .then(function(result) {
                    $scope.PersonQuestionnaireResult = result;
                   $scope.PersonQuestionnaireCalculated = true;
                });
                $scope.QuestionnaireFinished = true;
            })
            .catch(function (data) {
                alert("error");
            });                          
        };

        $scope.getQuestionnaireResult = function(id) {
            return PersonQuestionnaire.get({id : id}).$promise;
        };

        $scope.makeLogin = function (username,password) {
            return Person.login({ username: username, password: password }).$promise;
        };


        $scope.fakeResult = function () {
            $scope.getQuestionnaireResult(2)
                .then(function (result) {
                    $scope.PersonQuestionnaireResult = result;
                    $scope.PersonQuestionnaireCalculated = true;
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
                    } else if (selectedAnswers < 1) {
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
                WizardHandler.wizard().next();
            }            
        };

        
        $scope.validatePerson = function (person) {

            var fieldInvalid = false;
            
            if ((typeof (person) === "undefined") ||                
                (person.BirthDate == "" || typeof (person.BirthDate) === "undefined" || $('#tbBirthDate').$invalid) ||
                (person.Email == "" || typeof (person.Email) === "undefined") ||
                (person.Gender == "" || typeof (person.Gender) === "undefined"))
            {
                fieldInvalid = true;                
            }
                
            if (!fieldInvalid) {

                if (!person.PrivacyLawAgree) {
                    $scope.PersonErrorText = "* è necessario acconsentire alla legge sulla privacy";
                } else {
                    WizardHandler.wizard().next();
                    $scope.PersonErrorText = "";
                }
                
            } else {
                $scope.PersonErrorText = "* è necessario compilare i campi obbligatori";
            }
        };

        $scope.validateLogin = function (person) {

            var fieldInvalid = false;

            if ((typeof (person) === "undefined") ||                
                (person.UserName == "" || typeof (person.UserName) === "undefined") ||
                (person.Password == "" || typeof (person.Password) === "undefined"))                
            {
                fieldInvalid = true;
            }

            if (fieldInvalid == false) {
                $scope.makeLogin(person.UserName, person.Password)
                    .then(function (result) {
                        if (result.Id != "" && result.Id > 0) {
                            $scope.PersonQuestionnaireToFill.PersonId = result.Id;
                            $scope.PersonQuestionnaireToFill.Person = result;
                            WizardHandler.wizard().next();
                        } else {
                            $scope.PersonLoginErrorText = "* Login non valida!";
                        }
                        
                    }, function (reason) {
                        $scope.PersonLoginErrorText = "* Login non valida!";
                    });
            } else {
                $scope.PersonLoginErrorText = "* Login non valida!";
            }
            
        };

        $scope.continueWithoutLogin = function() {
            WizardHandler.wizard().next();
        };


    }]);