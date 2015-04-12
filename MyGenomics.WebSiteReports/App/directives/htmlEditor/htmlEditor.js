app.directive('richtexteditor', function () {
    return {
        restrict: "A",
        require: 'ngModel',
        replace: true,
        transclude: true,
        template: "<div><textarea style='width: 100%; height: 200px; font-size: 14px; line-height: 18px; border: 1px solid #dddddd; padding: 10px;'></textarea></div>",
        link: function (scope, element, attrs, ctrl) {
            var textarea = $(element.find('textarea')).wysihtml5();
            var editor = textarea.data('wysihtml5').editor;

            // view -> model
            editor.on('change', function () {
                scope.$apply(function () {
                    ctrl.$setViewValue(editor.getValue());
                });
            });

            // model -> view
            ctrl.$render = function () {
                textarea.html(ctrl.$viewValue);
                editor.setValue(ctrl.$viewValue);
            };

            /* - similar to above
            scope.$watch(attrs.ngModel, function(newValue, oldValue) {
                textarea.html(newValue);
                editor.setValue(newValue);
            });
            */

            // load init value from DOM
            ctrl.$render();
        }
    };
});