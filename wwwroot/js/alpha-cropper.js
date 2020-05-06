function alphaCropper(data={
    fileSelector:'',
    imageSelector:'',
    croppWidth:0,
    croppHeight:0,
    controlSelectors: {
        x:"#x",
        y:"#y",
        width:"#Width",
        height:"#Height"
    }
}) {

   
    var ImageElement = document.querySelector(data.fileSelector)
    ImageElement.onchange = function (a) {

        let ImageFile = a.srcElement.files[0];
        let reader = new FileReader();
        reader.readAsDataURL(ImageFile);
        reader.onload = function (a) {

            $(data.imageSelector).attr("src", a.currentTarget.result);
            $(data.imageSelector).css({ "display": "inline-block", "width": "100%", "height": "100vh" });
            $("#imageContainer").css({"display":"block"});
          
            var $toCrop = $(data.imageSelector);
            $toCrop.cropper({
                strict: true,
                cropBoxResizable: false,
                autoCropArea: 0,
                resize: false,
                strict: false,

                highlight: false,
                dragCrop: false,
                zoomable: true,
                zoomOnTouch: true,
                zoomOnWheel: true,
                viewMode: 2,

                dragMode: 3,


                ready: function () {
                    $toCrop.cropper("setCropBoxData", { width: data.croppWidth, height: data.croppHeight });
                },
                crop: function (event) {

                    console.log(event.detail);
                    $(data.controlSelectors.x).val(event.detail.x);
                    $(data.controlSelectors.y).val(event.detail.y);
                    $(data.controlSelectors.width).val(event.detail.width);
                    $(data.controlSelectors.height).val(event.detail.height);

                }

            });


        }
    }


}