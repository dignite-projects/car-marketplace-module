
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
})();