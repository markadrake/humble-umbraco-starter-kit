// AngularJS code
angular.module('umbraco').controller('humble_propertyEditors_iconPickerController', function ($scope, editorService) {
    if(!$scope.model.value)
        $scope.model.value = "";
    
    var submit = (submitData) => {
        $scope.model.value = submitData.icon;
        editorService.close();
    };
    
    var close = (closeData) => {
        editorService.close();
    };
    
    $scope.openEditor = () => {
        editorService.iconPicker({
            color: "black",
            icon: $scope.model.value,
            submit,
            close
        });
    };
    
});