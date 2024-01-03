
(function () {

    //
    const scrollSpy = new bootstrap.ScrollSpy(document.body, {
        target: '#car-config'
    });

    //收藏
    $('button[name="btnFavorite"]').click(function () {
        var id = $(this).data('id');
        abp.notify.success(
            '系统已将该车放进您的收藏夹。',
            '提示'
        );
    });

    $('#BuyUsedCarModal button[name="btnSubmit"]').click(function (e) {
        e.stopPropagation();
        e.preventDefault();
        var $form = $('#consultation-form');
        if ($form.valid()) {
            let formData = {};
            let formValue = $form.serializeArray();
            $.each(formValue, function (index, item) {
                formData[item.name] = item.value;
            });
            dignite.carMarketplace.public.usedCars.buyUsedCar
                .create(formData)
                .then(function (result) {
                    $form[0].reset();
                    $('#BuyUsedCarModal button[name="btnClose"]').click();
                    abp.message.success('您的预约看车已成功提交!', '提示');              
                });
        }
    });
})();