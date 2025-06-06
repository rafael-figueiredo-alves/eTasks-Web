// In development, always fetch from the network and do not enable offline support.
// This is because caching would make development more difficult (changes would not
// be reflected on the first load after each change).
self.addEventListener('fetch', () => { });


//const CACHE_NAME = 'etasks-cache-v1';
//const urlsToCache = [
//    '/',
//    '/manifest.webmanifest',
//    '/css/bootstrap/bootstrap.min.css',
//    '/css/app.css',
//    '/eTasks.styles.css',
//    '/assets/favicon.webp',
//    '/assets/icon-180.webp',
//    '/assets/icon-192.webp',
//    '/assets/icon-512.webp',
//    '/assets/shortcut-new-task-96.webp',
//    '/dotnet.wasm',
//    '/blazor.boot.json',
//    '/_framework/blazor.webassembly.js'
//    // Adicione aqui os arquivos .dll específicos gerados pelo Blazor, ex.:
//    // '/_framework/YourApp.dll',
//    // '/_framework/System.Collections.dll',
//    // etc. (veja a lista completa no arquivo blazor.boot.json ou na pasta _framework)
//];

//// Lista dinâmica de arquivos .dll será adicionada no evento 'install'
//const dynamicCacheFiles = [];

//// Evento 'install': armazena arquivos estáticos e runtime do .NET em cache
//self.addEventListener('install', event => {
//    event.waitUntil(
//        caches.open(CACHE_NAME).then(cache => {
//            // Faz cache dos arquivos estáticos
//            return cache.addAll(urlsToCache).then(() => {
//                // Opcional: carregar dinamicamente os arquivos .dll listados em blazor.boot.json
//                return fetch('/blazor.boot.json').then(response => {
//                    if (response.ok) {
//                        return response.json().then(bootConfig => {
//                            const dllFiles = Object.keys(bootConfig.resources.assembly).map(
//                                key => `/_framework/${key}`
//                            );
//                            dynamicCacheFiles.push(...dllFiles);
//                            return cache.addAll(dllFiles);
//                        });
//                    }
//                });
//            });
//        })
//    );
//    // Força a ativação imediata do novo Service Worker
//    self.skipWaiting();
//});

//// Evento 'activate': limpa caches antigos para garantir atualizações
//self.addEventListener('activate', event => {
//    event.waitUntil(
//        caches.keys().then(cacheNames => {
//            return Promise.all(
//                cacheNames
//                    .filter(name => name !== CACHE_NAME)
//                    .map(name => caches.delete(name))
//            );
//        })
//    );
//    // Força os clientes a usarem o novo Service Worker
//    self.clients.claim();
//});

//// Evento 'fetch': estratégia Cache-First com fallback para rede
//self.addEventListener('fetch', event => {
//    // Ignora cache em desenvolvimento local (localhost)
//    if (self.location.hostname === 'localhost' || self.location.hostname === '127.0.0.1') {
//        return;
//    }

//    // Ignora requisições que não são GET ou que não são do mesmo domínio
//    if (event.request.method !== 'GET' || !event.request.url.startsWith(self.location.origin)) {
//        event.respondWith(fetch(event.request));
//        return;
//    }

//    event.respondWith(
//        caches.match(event.request).then(cachedResponse => {
//            // Retorna do cache, se disponível
//            if (cachedResponse) {
//                // Faz uma requisição em segundo plano para atualizar o cache
//                event.waitUntil(
//                    fetch(event.request).then(networkResponse => {
//                        if (networkResponse.ok) {
//                            return caches.open(CACHE_NAME).then(cache => {
//                                cache.put(event.request, networkResponse.clone());
//                                return networkResponse;
//                            });
//                        }
//                        return networkResponse;
//                    })
//                );
//                return cachedResponse;
//            }

//            // Se não estiver no cache, busca na rede
//            return fetch(event.request).then(networkResponse => {
//                if (networkResponse.ok) {
//                    // Armazena no cache para requisições futuras
//                    return caches.open(CACHE_NAME).then(cache => {
//                        cache.put(event.request, networkResponse.clone());
//                        return networkResponse;
//                    });
//                }
//                return networkResponse;
//            }).catch(() => {
//                // Fallback offline: retorna uma página ou mensagem personalizada, se necessário
//                return caches.match('/');
//            });
//        })
//    );
//});
