(function () {
    'use strict';

    angular
        .module('article.controllers', [])
        .controller('ArticleController', ArticleController);

    ArticleController.$inject = ['articleFactory', '$scope', '$routeParams'];

    function ArticleController(articleFactory, $scope, $routeParams) {
        /* jshint validthis:true */
        var vm = this;
        vm.articles = [];

        activate();

        function activate() {
            getArticles();
        }

        function getArticles() {
            return articleFactory.getArticles()
                .then(function (data) {
                    vm.articles = data;
                    return vm.articles;
                })
                .catch(function (data) {
                    $scope.errorGetArticles = data;
                });
        }

        $scope.getArticleById = function(articleId) {
            return articleFactory.getArticleById(articleId)
                .then(function (data) {
                    vm.articles = data;
                    return vm.articles;
                })
        }
        
        $scope.getArticlesByStore = function (storeId) {
            return articleFactory.getArticlesByStore(storeId)
                .then(function (data) {
                    vm.articles = data;
                    return vm.articles;
                })
        }

        $scope.saveArticle = function (article) {

            $scope.article = {
                'article': {
                    'Name': article.name,
                    'Description': article.description,
                    'Price': article.price,
                    'TotalInShelf': article.totalinshelf,
                    'TotalInVault': article.totalinvault
                }
            };

            articleFactory.saveArticle($scope.book)
                .then(function (data) {
                    alert("The article was added!!");
                })
                .catch(function (data) {
                    $scope.errorArticle = data;
                });
        }

        $scope.updateArticle = function (article, articleId) {

            $scope.article = {
                'article': {
                    'Name': article.name,
                    'Description': article.description,
                    'Price': article.price,
                    'TotalInShelf': article.totalinshelf,
                    'TotalInVault': article.totalinvault
                }
            }
            articleFactory.updateArticle($scope.article, articleId)
                .then(function (data) {
                    alert("The article was updated!!");
                })
                .catch(function (data) {
                    $scope.errorUpdate = data;                    
                })
        }
        $scope.deleteArticle = function (article) {
            $scope.article = {
                'article': {
                    'id': article.id
                }
            }
            articleFactory.deleteArticle($scope.article)
                .then(function (data) {
                    alert('The article was deleted!!')
                })
                .catch(function (data) {
                    $scope.errorDelete = data;
                })
        }
    }
})();
