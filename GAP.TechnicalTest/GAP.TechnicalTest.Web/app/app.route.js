(function () {
    angular
        .module('app.route', [])
            .config(config);

    function config($routeProvider, $locationProvider, $qProvider) {

        $routeProvider
            .when('/', {
                templateUrl: '/App/article/article.html',
                controller: 'ArticleController',
                controllerAs: 'vm'
            })
            .when('/articlebyid', {
                templateUrl: '/App/article/articlebyid.html',
                controller: 'ArticleController',
                controllerAs: 'vm'
            })
            .when('/articlebystore', {
                templateUrl: '/App/article/articlebystore.html',
                controller: 'ArticleController',
                controllerAs: 'vm'
            })
            .when('/addarticle', {
                templateUrl: '/App/article/AddArticle.html',
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
        $qProvider.errorOnUnhandledRejections(false);
    };
})();