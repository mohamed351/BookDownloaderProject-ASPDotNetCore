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
        $toCrop = null;
        let ImageFile = a.srcElement.files[0];
        let reader = new FileReader();
        reader.readAsDataURL(ImageFile);
        reader.onload = function (a) {

            $(data.imageSelector).attr("src", a.currentTarget.result);
            $(data.imageSelector).css({ "display": "inline-block" });
            $("#imageContainer").css({ "display": "block" });
            $(data.imageSelector).cropper('destroy');
          
             $toCrop = $(data.imageSelector);
            $toCrop.cropper({
                strict: true,
                cropBoxResizable: false,
                autoCropArea: 0,
                resize: false,
                strict: false,

                highlight: false,
                dragCrop: false,
                zoomable: false,
                zoomOnTouch: false,
                zoomOnWheel: false,
                viewMode: 1,

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