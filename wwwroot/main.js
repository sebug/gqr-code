const transformTextBox = document.querySelector('#totransform');
const cvs = document.querySelector('canvas');

console.log(cvs);

const paintQrCodeTable = (table) => {
    let ctx = cvs.getContext('2d');
    ctx.clearRect(0, 0, 500, 500);
    for (let y = 0; y < table.length; y += 1) {
        let row = table[y];
        for (let x = 0; x < row.length; x += 1) {
            if (row[x]) {
                ctx.fillStyle = 'black';
                ctx.fillRect(x, y, 1, 1);
            }
        }
    }
};

const getQrCode = async (url) => {
    const responseText = await fetch('/qrcode?text=' + encodeURIComponent(url));
    const responseObject = await responseText.json();
    paintQrCodeTable(responseObject.table);
};

transformTextBox.addEventListener('change', ev => {
    getQrCode(ev.target.value);
});