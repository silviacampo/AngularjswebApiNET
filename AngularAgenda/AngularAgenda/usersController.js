function userController($scope, $http) {
    $scope.username = '';
    $scope.email = '';
    $scope.passw1 = '';
    $scope.passw2 = '';
    $http.get("http://localhost:8086/api/Users").success(function (response) {
      $scope.users = response;
  });
    //$scope.users = [
//{ id: 1, fName: 'Hege', lName: "Pege" },
//{ id: 2, fName: 'Kim', lName: "Pim" },
//{ id: 3, fName: 'Sal', lName: "Smith" },
//{ id: 4, fName: 'Jack', lName: "Jones" },
//{ id: 5, fName: 'John', lName: "Doe" },
//{ id: 6, fName: 'Peter', lName: "Pan" }
//];
    $scope.edit = false;
    $scope.add = false;
    $scope.error = false;
    $scope.incomplete = false;

    $scope.editUser = function (id) {
        if (id == 'new') {
            $scope.edit = false;
            $scope.add = true;
            $scope.incomplete = true;
            $scope.username = '';
            $scope.email = '';
        } else {
            $scope.edit = true;
            $scope.add = false;
            $scope.username = $scope.users[id-1].username;
            $scope.email = $scope.users[id-1].email;
        }
    };
    $scope.saveUser = function () {
        $http.post("http://localhost:8086/api/Users", { username: $scope.user, email: $scope.email }).
        error(function (data, status, headers, config) { alert(data.toString() + status.toString()); })
        .success(function (response) {
        alert("saved1"); 
  });
    alert("saved2");     
        };

    $scope.$watch('passw1', function () { $scope.test(); });
    $scope.$watch('passw2', function () { $scope.test(); });
    $scope.$watch('username', function () { $scope.test(); });
    $scope.$watch('email', function () { $scope.test(); });

    $scope.test = function () {
        if ($scope.passw1 !== $scope.passw2) {
            $scope.error = true;
        } else {
            $scope.error = false;
        }
        $scope.incomplete = false;
        if ($scope.edit && (!$scope.username.length ||
  !$scope.email.length ||
  !$scope.passw1.length || !$scope.passw2.length)) {
            $scope.incomplete = true;
        }
    };

}