window.createQrCode = function ( Uri) {
  new QRCode(document.getElementById("qrCode"),
    {
      text: Uri,
      width: 150,
      height: 150
    });
}