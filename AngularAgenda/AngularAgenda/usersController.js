function userController($scope, $http) {
    $scope.user = {};
    $scope.user.username = '';
    $scope.user.email = '';
    $scope.user.passw1 = '';
    $scope.user.passw2 = '';
    $scope.user.id = 0;
    
    $http.get("http://localhost:8086/api/Users").success(function (response) 
        { 
            $scope.users = response;
        });

    $scope.edit = false;
    $scope.add = false;
    $scope.error = false;
    $scope.incomplete = false;

    $scope.editUser = function (id) 
        {
            if (id == 'new') {
                $scope.edit = false;
                $scope.add = true;
                $scope.incomplete = true;
                $scope.user.username = '';
                $scope.user.email = '';
                $scope.user.id= 0;
            } else {
                $scope.edit = true;
                $scope.add = false;
                $scope.user.username = $scope.users[id].username;
                $scope.user.email = $scope.users[id].email;
                $scope.user.id = $scope.users[id].id;
            }
        };
    
    $scope.showMessage = function(msg) 
        { 
            alert(msg); 
        };

    $scope.saveUser = function () 
        {
            if ($scope.user.id == 0) //Create
            {
                $http.post("http://localhost:8086/api/Users/", 
                        { "id": $scope.user.id, 
                        "username": $scope.user.username, 
                        "password": $scope.user.passw1, 
                        "email": $scope.user.email, 
                        "isAdmin": 0 
                        })
                        .error(function (data, status, headers, config) 
                            {
                                $scope.showMessage("save fails"); 
                            })
                        .success(function (response) 
                            {
                                $scope.showMessage("user saved");
                                $http.get("http://localhost:8086/api/Users").success(function (response) 
                                    {
                                        $scope.users = response;
                                    });
                        });
            }
            else //Edit
            {
                $http.put("http://localhost:8086/api/Users/" + $scope.user.id, 
                        { "id": $scope.user.id, 
                        "username": $scope.user.username, 
                        "password": $scope.user.passw1, 
                        "email": $scope.user.email, 
                        "isAdmin": 0
                        })
                        .error(function (data, status, headers, config) 
                            { 
                                $scope.showMessage("save fails"); 
                            })
                        .success(function (response) 
                            {
                                $scope.showMessage("user saved");
                                $http.get("http://localhost:8086/api/Users").success(function (response) 
                                    {
                                        $scope.users = response;
                                    });
                            });
           }
            $scope.user.username = '';
            $scope.user.email = '';
            $scope.user.passw1 = '';
            $scope.user.passw2 = '';
            $scope.user.id = 0;
        };

    $scope.deleteUser = function (id) 
        {
            $http.delete("http://localhost:8086/api/Users/" + id)
                    .error(function (data, status, headers, config) 
                        { 
                            $scope.showMessage("delete fails"); 
                        })
                    .success(function (response) 
                        {  
                            $scope.showMessage("user deleted");          
                            $http.get("http://localhost:8086/api/Users")
                                    .success(function (response) 
                                        {
                                            $scope.users = response;
                                        });
                         });
    
        };

    $scope.$watch('user.passw1', function () { $scope.test(); });
    $scope.$watch('user.passw2', function () { $scope.test(); });
    $scope.$watch('user.username', function () { $scope.test(); });
    $scope.$watch('user.email', function () { $scope.test(); });

    $scope.test = function () {
        if ($scope.user.passw1 !== $scope.user.passw2) {
            $scope.error = true;
        } else {
            $scope.error = false;
        }
        $scope.incomplete = false;
        if (($scope.edit || $scope.add) && (!$scope.user.username.length || !$scope.user.email.length ||
                !$scope.user.passw1.length || !$scope.user.passw2.length)) 
        {
            $scope.incomplete = true;
        }
    };

}