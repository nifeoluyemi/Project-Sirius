// the image cropper script...

var $uploadcrop;

$('#closedialog').click(function () {
    $('#cropbox').modal("hide");
});

$('#wizard-picture').change(function () {
    readURL(this);
    $('#cropbox').modal("show");
});

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $uploadcrop.croppie('bind', {
                url: e.target.result
            });
        }
        reader.readAsDataURL(input.files[0]);
    }
}


$uploadcrop = $('#canvas').croppie({
    viewport: {
        width: 200,
        height: 200
    },
    boundary: {
        width: 250,
        height: 250
    }
});

$('#result').click(function (ev) {
    $uploadcrop.croppie('result', {
        type: 'canvas',
        size: {
            width: 250,
            height: 250
        }
    }).then(function (resp) {
        $('#wizardPicturePreview').attr('src', resp).fadeIn('slow');
        $('#cropbox').modal("hide");
        $('#croppedImage').val(resp);
    });
});