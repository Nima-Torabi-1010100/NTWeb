document.addEventListener('DOMContentLoaded', () => {

    // Elements
    const introSection = document.getElementById('intro-section');
    const mainSection = document.getElementById('main-section');
    const ctaButton = document.querySelector('.intro-cta-button');
    const canvas = document.getElementById('intro-canvas');
    const cursor = document.querySelector('.intro-custom-cursor');

    if (!introSection || !mainSection || !ctaButton || !canvas) return;

    let width = canvas.width = window.innerWidth;
    let height = canvas.height = window.innerHeight;

    let mouseX = width / 2;
    let mouseY = height / 2;
    let targetX = mouseX;
    let targetY = mouseY;

    const ctx = canvas.getContext('2d');

    // Load background image
    const img = new Image();
    let imageData = null;
    let imageLoaded = false;

    img.onload = function () {
        const tempCanvas = document.createElement('canvas');
        tempCanvas.width = width;
        tempCanvas.height = height;
        const tempCtx = tempCanvas.getContext('2d');

        const imgRatio = img.width / img.height;
        const canvasRatio = width / height;
        let drawWidth, drawHeight, offsetX = 0, offsetY = 0;

        if (imgRatio > canvasRatio) {
            drawHeight = height;
            drawWidth = height * imgRatio;
            offsetX = (width - drawWidth) / 2;
        } else {
            drawWidth = width;
            drawHeight = width / imgRatio;
            offsetY = (height - drawHeight) / 2;
        }

        tempCtx.drawImage(img, offsetX, offsetY, drawWidth, drawHeight);

        // Dark overlay
        tempCtx.fillStyle = 'rgba(0, 0, 0, 0.3)';
        tempCtx.fillRect(0, 0, width, height);

        imageData = tempCtx.getImageData(0, 0, width, height);
        imageLoaded = true;

        animate();
    };

    img.src = '/images/intro-background.jpg';

    // Mouse movement
    document.addEventListener('mousemove', (e) => {
        targetX = e.clientX;
        targetY = e.clientY;
        if (cursor) {
            cursor.style.left = e.clientX + 'px';
            cursor.style.top = e.clientY + 'px';
        }
    });

    function updateMousePosition() {
        mouseX += (targetX - mouseX) * 0.1;
        mouseY += (targetY - mouseY) * 0.1;
    }

    function drawWaveEffect() {
        if (!imageLoaded) return;

        const distortedImageData = ctx.createImageData(width, height);
        const pixels = distortedImageData.data;
        const originalPixels = imageData.data;

        for (let y = 0; y < height; y++) {
            for (let x = 0; x < width; x++) {
                const index = (y * width + x) * 4;
                const dx = x - mouseX;
                const dy = y - mouseY;
                const distance = Math.sqrt(dx * dx + dy * dy);
                const maxDistance = 200;

                if (distance < maxDistance) {
                    const power = (maxDistance - distance) / maxDistance;
                    const angle = Math.atan2(dy, dx);
                    const wave = Math.sin(distance * 0.05 - Date.now() * 0.002) * 30 * power;
                    const offsetX = Math.cos(angle) * wave;
                    const offsetY = Math.sin(angle) * wave;

                    const srcX = Math.min(Math.max(Math.floor(x + offsetX), 0), width - 1);
                    const srcY = Math.min(Math.max(Math.floor(y + offsetY), 0), height - 1);
                    const srcIndex = (srcY * width + srcX) * 4;

                    pixels[index] = originalPixels[srcIndex];
                    pixels[index + 1] = originalPixels[srcIndex + 1];
                    pixels[index + 2] = originalPixels[srcIndex + 2];
                    pixels[index + 3] = 255;
                } else {
                    pixels[index] = originalPixels[index];
                    pixels[index + 1] = originalPixels[index + 1];
                    pixels[index + 2] = originalPixels[index + 2];
                    pixels[index + 3] = 255;
                }
            }
        }
        ctx.putImageData(distortedImageData, 0, 0);
    }

    function animate() {
        updateMousePosition();
        drawWaveEffect();
        requestAnimationFrame(animate);
    }

    // Handle window resize
    window.addEventListener('resize', () => {
        width = canvas.width = window.innerWidth;
        height = canvas.height = window.innerHeight;
        if (img.complete) img.onload();
    });

    // CTA button click → fade out intro, show main section
    ctaButton.addEventListener('click', () => {
        introSection.style.transition = 'opacity 1s ease';
        introSection.style.opacity = '0';

        setTimeout(() => {
            introSection.style.display = 'none';
            mainSection.style.display = 'block';
            mainSection.style.opacity = '0';
            requestAnimationFrame(() => {
                mainSection.style.transition = 'opacity 1s ease';
                mainSection.style.opacity = '1';
            });
        }, 1000);
    });

});