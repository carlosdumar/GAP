(function () {
    angular
        .module('app.route', [])
            .config(config);

    function config($routeProvider, $locationProvider) {

        $routeProvider
            .when('/articles', {
                templateUrl: '/App/article/article.html',
                controller: 'ArticleController',
                controllerAs: 'vm'
            })
            .when('/stores', {
                templateUrl: '/App/store/store.html',
                controller: 'StoreController',
                controllerAs: 'vm'
            });

        $locationProvider
            .html5Mode({
                enabled: true,
                requireBase: false
            });
    };
})();