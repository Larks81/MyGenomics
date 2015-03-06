angular.module('MyGenomicsApp')
.controller('questionarioController', ['$scope', 'Questionnaire','PersonQuestionnaire','WizardHandler',
    function ($scope, Questionnaire, PersonQuestionnaire, WizardHandler) {

        $scope.Questionnaires = null;
        $scope.SelectedQuestionnaire = null;
        $scope.PersonQuestionnaireToFill = null;
        $scope.TotStep = null;
        $scope.ReadyToLoad = false;
        $scope.PersonErrorText = "";
        $scope.QuestionnaireFinished = false;
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
            var personQuestionnaire = new PersonQuestionnaire();
            personQuestionnaire.QuestionnaireId = questionnaire.Id;
            personQuestionnaire.Answers = new Array();            
            for (var k = 0 ; k < questionnaire.Questions.length ; k++) {
                var personAnswer = new Object();
                personAnswer.QuestionIndex = k;
                personAnswer.QuestionId = questionnaire.Questions[k].Id;
                personAnswer.QuestionText = questionnaire.Questions[k].Text;
                personAnswer.QuestionCategory = questionnaire.Questions[k].Category.Name;
                personAnswer.PossibileAnswers = questionnaire.Questions[k].Anwers;
                personAnswer.AnswerId = 0;
                personAnswer.IsRequired = questionnaire.Questions[k].IsRequired;
                personAnswer.ErrorText = "";
                personQuestionnaire.Answers.push(personAnswer);
            }
            $scope.TotStep = GetTotStepInPersonQuestionnaire(personQuestionnaire);
            $scope.PersonQuestionnaireToFill = personQuestionnaire;
            $scope.ReadyToLoad = true;
        };

        $scope.submit = function() {
            PersonQuestionnaire.save($scope.PersonQuestionnaireToFill);
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

            //var fieldInvalid = false;
            
            //if ((typeof (person) === "undefined") ||
            //    (person.FirstName == "" || typeof (person.FirstName) === "undefined") ||
            //    (person.LastName == "" || typeof (person.LastName) === "undefined") ||
            //    (person.City == "" || typeof (person.City) === "undefined") ||
            //    (person.Address == "" || typeof (person.Address) === "undefined") ||
            //    (person.BirthDate == "" || typeof (person.BirthDate) === "undefined") ||
            //    (person.BirthCity == "" || typeof (person.BirthCity) === "undefined") ||
            //    (person.PhoneNumber == "" || typeof (person.PhoneNumber) === "undefined") ||
            //    (person.Email == "" || typeof (person.Email) === "undefined") ||
            //    (person.PersonalDoctor == "" || typeof (person.PersonalDoctor) === "undefined"))
            //{
            //    fieldInvalid = true;                
            //}
                
            //if (!fieldInvalid) {
                WizardHandler.wizard().next();
                $scope.PersonErrorText = "";
            //} else {
            //    $scope.PersonErrorText = "* è necessario compilare tutti i campi";
            //}
        };

        //--------------------------------------------------------------------
        //--------------Datepicker functions----------------------------------
        //--------------------------------------------------------------------

        $scope.clear = function () {
            $scope.dt = null;
        };

        // Disable weekend selection
        $scope.disabled = function (date, mode) {
            return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
        };

        $scope.toggleMin = function () {
            $scope.minDate = $scope.minDate ? null : new Date();
        };
        $scope.toggleMin();

        $scope.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();
            $scope.opened = true;
            setTimeout(function() {
            $scope.opened = false;
        }, 10);
        };

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };

        //--------------------------------------------------------------------
        //--------------Helper Functions--------------------------------------
        //--------------------------------------------------------------------

        function GetTotStepInPersonQuestionnaire(personQuestionnaire) {
            var totStep = 0;
            var currentStep = "";
            for (var k = 0 ; k < personQuestionnaire.Answers.length ; k++) {
                if (personQuestionnaire.Answers[k].QuestionCategory != currentStep) {
                    currentStep = personQuestionnaire.Answers[k].QuestionCategory;
                    totStep++;
                }
            }
            return totStep;
        }

    }]);