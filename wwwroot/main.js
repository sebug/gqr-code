const transformTextBox = document.querySelector('#totransform');

const getQrCode = async (url) => {
    const responseText = await fetch('/qrcode?text=' + encodeURIComponent(url));
    const responseObject = await responseText.json();
    console.log(responseObject);
};

transformTextBox.addEventListener('change', ev => {
    getQrCode(ev.target.value);
});