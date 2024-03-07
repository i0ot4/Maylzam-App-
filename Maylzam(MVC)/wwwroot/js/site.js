// الحصول على عنصر الفيديو والكاميرا
var videoElement = document.getElementById('videoElement');
var captureButton = document.getElementById('captureButton');
var canvasElement = document.getElementById('canvasElement');

// التأكد من توفر الكاميرا
navigator.mediaDevices.getUserMedia({ video: true })
    .then(function (stream) {
        videoElement.srcObject = stream;
    })
    .catch(function (error) {
        console.error('حدث خطأ في الوصول إلى الكاميرا: ', error);
    });

// التقاط الصورة عند النقر على زر "التقاط الصورة"
captureButton.addEventListener('click', function () {
    canvasElement.getContext('2d').drawImage(videoElement, 0, 0, canvasElement.width, canvasElement.height);
    var imageDataURL = canvasElement.toDataURL('image/png');

    // يمكنك إرسال الصورة الملتقطة إلى الخادم أو استخدامها في أي عملية أخرى
    // على سبيل المثال، يمكنك إنشاء عنصر صورة مصغرة وعرضه للمستخدم
    var thumbnailElement = document.createElement('img');
    thumbnailElement.src = imageDataURL;
    document.body.appendChild(thumbnailElement);
});