$(function () {
    var $brandSelect = $('#brandSelect');
    var $modelSelect = $('#modelSelect');
    
    $brandSelect.change(function () {
        var brandId = this.value;
        $modelSelect.children().each(function (i, option) {
            if (i > 0) {
                option.remove();
            }
        });
        if (brandId != "") {
            //加载车型列表
            dignite.carMarketplace.public.cars.model.getList({
                brandId:brandId
            }).then(function (result) {
                result.items.forEach((modelCompany) => {
                    var $group = $modelSelect.append('<optgroup label="' + modelCompany.name + '"></optgroup>');
                    modelCompany.models.forEach((model) => {
                        $group.append('<option value="' + model.id + '">' + model.name + '</option>');
                    });
                });
            });
        }
    });    
});