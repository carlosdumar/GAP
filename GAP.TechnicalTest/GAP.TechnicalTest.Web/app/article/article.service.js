(function () {
    'use strict';

    angular
        .module('article.services', [])
        .factory('articleFactory', articleFactory);

    articleFactory.$inject = ['$http', '$q', '$rootScope'];

    function articleFactory($http, $q, $rootScope) {
        return {
            getArticles: getArticles,
            getArticleById: getArticleById,
            getArticlesByStore: getArticlesByStore,
            saveArticle: saveArticle,
            updateArticle: updateArticle,
            deleteArticle: deleteArticle
        };
     
        function getArticles() {           

            return $http.get('http://localhost:50971/services/Article')
                .then(getArticlesComplete)
                .catch(getArticlesFailed);

            function getArticlesComplete(response, status, headers, config) {
                return response.data;
            }
            function getArticlesFailed(data, status, headers, config) {
                var errorMessage = "The request failed with response" + data + "and status code: " + status;
                return errorMessage;
            }
        }
        function getArticleById(article) {

            return $http.get('http://localhost:50971/api/Article/' + article.Id)
                .then(getArticleByIdComplete)
                .catch(getArticleByIdFailed);
            
            function getArticleByIdComplete(response, status, headers, config) {
                return response.data;
            }

            function getArticleByIdFailed(data, status, headers, config) {
                var errorMessage = "The request failed with response: " + data + "and status code: " + status;
                return errorMessage;
            }
        }

        function getArticlesByStore(article) {

            return $http.get('http://localhost:50971/services/Article/stores/' + article.StoreId)
                .then(getArticlesByStoreComplete)
                .catch(getArticlesByStoreFailed);

            function getArticlesByStoreComplete(response, status, headers, config) {
                return response.data;
            }

            function getArticlesByStoreFailed(data, status, headers, config) {
                var errorMessage = "The request failed with response: " + data + "and status code: " + status;
                return errorMessage;
            }
        }

        function saveArticle(article) {

            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: 'http://localhost:50971/api/Article/',
                data: article,
                headers:
                    {
                        'Accept': 'application/json, application/xml, text/play, text/html, *.*',
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
            })
            .then(saveArticleComplete)
            .catch(saveArticleFailed);

            function saveArticleComplete(data, status) {
                if (status === 200) {
                    defered.resolve(data);
                } else {
                    defered.reject();
                }
            }
            function saveArticleFailed(data, status) {

                return $q.reject("The request failed with reponse" + data + "and status code: " + status);
            }

            return defered.promise;
        }

        function updateArticle(articleId, article) {
            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'PUT',
                url: '/api/Article/' + articleId,
                data: $.param(article),
                headers:
                    {
                        'Accept': 'application/json, application/xml, text/play, text/html, *.*',
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
            })
            .success(updateArticleComplete)
            .catch(updateArticleFailed);

            function updateArticleComplete(data) {
                if (data.status === 200) {
                    defered.resolve(data);
                } else {
                    defered.reject();
                }
            }
            function updateArticleFailed(data, status) {

                return $q.reject("The request failed with reponse" + data + "and status code: " + status);
            }

            return promise;
        }

        function deleteArticle(article) {
            var defered = $q.defer();
            var promise = defered.promise;

            $http({
                method: 'DELETE',
                url: 'http://localhost:50971/api/Article/' + article.Id,
                headers:
                    {
                        'Accept': 'application/json, application/xml, text/play, text/html, *.*',
                        'Content-Type': 'application/json'
                    }
            })
            .then(function (response) {
                 defered.resolve(response);;
            }, function (data, status) {
                $q.reject("The request failed with reponse" + data + "and status code: " + status);
            });

            return defered.promise;
        }
    }
})();
