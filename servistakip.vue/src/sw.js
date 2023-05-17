// sw.js

// Service Worker dosyasının sürüm numarası
const version = 'v1';

// Dosyaların önbelleğe alınacağı adlar
const staticCacheName = `static-${version}`;
const dynamicCacheName = `dynamic-${version}`;

// Service Worker yüklendiğinde yapılacaklar
self.addEventListener('install', event => {
  event.waitUntil(
    caches.open(staticCacheName).then(cache => {
      // Gerekli dosyaları önbelleğe ekleme
      cache.addAll([
        '/',
        '/index.html',
        '/app.js',
        '/styles.css',
        // Ek dosyaları buraya ekleyebilirsiniz
      ]);
    }),
  );
});

// Service Worker etkin olduğunda yapılacaklar
self.addEventListener('activate', event => {
  event.waitUntil(
    // Eski önbelleği temizleme
    caches.keys().then(keys => {
      return Promise.all(
        keys.filter(key => key !== staticCacheName && key !== dynamicCacheName).map(key => caches.delete(key)),
      );
    }),
  );
});

// İsteğe yanıt verme
self.addEventListener('fetch', event => {
  event.respondWith(
    caches.match(event.request).then(cacheResponse => {
      return (
        cacheResponse ||
        fetch(event.request).then(fetchResponse => {
          return caches.open(dynamicCacheName).then(cache => {
            // İsteği önbelleğe ekleme ve yanıtı döndürme
            cache.put(event.request.url, fetchResponse.clone());
            return fetchResponse;
          });
        })
      );
    }),
  );
});
