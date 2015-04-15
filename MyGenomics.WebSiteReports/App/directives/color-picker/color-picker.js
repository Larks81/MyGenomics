angular.module('MyGenomicsApp').directive('colorpicker', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {           
            $(element).colorpicker();
        }
    };
}); 