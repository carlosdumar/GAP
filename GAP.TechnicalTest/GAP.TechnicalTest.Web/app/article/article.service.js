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
            var defered = $q.defered;
            var promise = defered.promise;

            return $http.get('/services/Article')
                .then(getArticlesComplete)
                .catch(getArticlesFailed);

            function getArticlesComplete(data, status, headers, config) {
                defered.resolve(data);
            }
            function getArticlesFailed(data, status, headers, config) {
                return $q.reject("The request failed with response" + data + "and status code: " + status);
            }

            return promise;
        }
        function getArticleById(articleId) {
            var defered = $q.defered;
            var promise = defered.promise;

            return $http.get('/services/Article/' + articleId)
                .then(getArticleByIdComplete)
                .catch(getArticleByIdFailed);
            
            function getArticleByIdComplete(data, status, headers, config) {
                defered.resolve(data);
            }

            function getArticleByIdFailed(data, status, headers, config) {
                return $q.reject("The request failed with response" + data + "and status code: " + status);
            }

            return promise;
        }

        function getArticlesByStore(storeId) {
            var defered = $q.defered;
            var promise = defered.promise;

            return $http.get('/services/Article/store/' + storeId)
                .then(getArticlesByStoreComplete)
                .catch(getArticlesByStoreFailed);

            function getArticlesByStoreComplete(data, status, headers, config) {
                defered.resolve(data);
            }

            function getArticlesByStoreFailed(data, status, headers, config) {
                return $q.reject("The request failed with response" + data + "and status code: " + status);
            }

            return promise;
        }

        function saveArticle(article) {

            var defered = $q.defer;
            var promise = defered.promise;

            $http({
                method: 'POST',
                url: '/services/Article',
                data: $.param(article),
                headers:
                    {
                        'Accept': 'application/json, application/xml, text/play, text/html, *.*',
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
            })
            .success(saveArticleComplete)
            .error(saveArticleFailed);

            function saveArticleComplete(data) {
                if (data.status === 200) {
                    defered.resolve(data);
                } else {
                    defered.reject();
                }
            }
            function saveArticleFailed(data, status) {

                return $q.reject("The request failed with reponse" + data + "and status code: " + status);
            }

            return promise;
        }

        function updateArticle(articleId, article) {
            var defered = $q.defer;
            var promise = defered.promise;

            $http({
                method: 'PUT',
                url: '/services/Article/' + articleId,
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

        function deleteArticle(articleId) {
            var defered = $q.defer;
            var promise = defered.promise;

            $http({
                method: 'DELETE',
                url: '/services/Article/' + articleId,
                headers:
                    {
                        'Accept': 'application/json, application/xml, text/play, text/html, *.*',
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
            })
            .success(deleteArticleComplete)
            .catch(deleteArticleFailed);

            function deleteArticleComplete(data) {
                if (data.status === 200) {
                    defered.resolve(data);
                } else {
                    defered.reject();
                }
            }
            function deleteArticleFailed(data, status) {

                return $q.reject("The request failed with response" + data + "and status code: " + status);
            }

            return promise;
        }
    }
})();
