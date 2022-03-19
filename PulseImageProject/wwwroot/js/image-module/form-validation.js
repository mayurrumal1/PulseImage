$(function () {
    $('form[id="imageForm"]').validate({
        rules: {
            title: {
                required: true,
                maxlength: 100
            },
            imageFile: {
                required: true
            }
        },
        messages: {
            title: {
                required: 'Title is required.',
                maxLength: 'Allowed max length is 100.'
            },
            imageFile: {
                required: "Image is required."
            }
        }
    });
});