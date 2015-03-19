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
            Questionnaire.query( function (data) {
                $scope.Questionnaires = data;
                $scope.selectQuestionnaire($scope.Questionnaires[0]);
            });                        
        };

        $scope.selectQuestionnaire = function (questionnaire) {            
            Questionnaire.get({id: questionnaire.Id }, function (data) {
                $scope.SelectedQuestionnaire = data;
                $scope.buildPersonQuestionnaire(data);
            });            
        };

        $scope.buildPersonQuestionnaire = function (questionnaire) {
            
            for (var cat = 0; cat < questionnaire.QuestionsCategories.length; cat++) {
                for (var quest = 0; quest < questionnaire.QuestionsCategories[cat].Questions.length; quest++) {
                    questionnaire.QuestionsCategories[cat].Questions[quest].GivenAnswerId = 0;
                    questionnaire.QuestionsCategories[cat].Questions[quest].AdditionalInfo = "";
                    questionnaire.QuestionsCategories[cat].Questions[quest].ErrorText = "";
                }
            }

            $scope.PersonQuestionnaireToFill = questionnaire;
            $scope.TotStep = questionnaire.QuestionsCategories.length;
            $scope.ReadyToLoad = true;            
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

                    personQuestionnaire.GivenAnswers[nQuestion] = new Object();
                    personQuestionnaire.GivenAnswers[nQuestion].QuestionId = questionnaire.QuestionsCategories[cat].Questions[quest].Id;
                    personQuestionnaire.GivenAnswers[nQuestion].AnswerId = questionnaire.QuestionsCategories[cat].Questions[quest].GivenAnswerId;
                    personQuestionnaire.GivenAnswers[nQuestion].AdditionalInfo = questionnaire.QuestionsCategories[cat].Questions[quest].AdditionalInfo;
                    nQuestion++;
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
            $scope.getQuestionnaireResult(1)
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
                if (questions[k].IsRequired && (questions[k].AnswerId == null || questions[k].AnswerId == 0)) {
                    questions[k].ErrorText = "* Risposta necessaria";
                    fieldInvalid++;
                } else {
                    questions[k].ErrorText = "";
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
                WizardHandler.wizard().next();
                $scope.PersonErrorText = "";
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