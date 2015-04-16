angular.module('MyGenomicsApp')
.directive('modal', function () {
    return {
        templateUrl: '/app/directives/modal/modal.html',
        restrict: 'E',
        transclude: true,
        replace: true,
        //scope: true,
        scope: {           
            okclick: '&okclick',
        },
        link: function postLink(scope, element, attrs) {
            //scope.title = attrs.title;
            //scope.message = attrs.message;   
            scope.okclick = attrs.okclick;

            scope.$watch(attrs.visible, function (value) {
                alert(value);
                if(value == true)
                    $(element).modal('show');
                else
                    $(element).modal('hide');
            });

            $(element).on('shown.bs.modal', function(){
                scope.$apply(function(){
                    scope.$parent[attrs.visible] = true;
                });
            });

            $(element).on('hidden.bs.modal', function(){
                scope.$apply(function(){
                    scope.$parent[attrs.visible] = false;
                });
            });
        }
    };
});

