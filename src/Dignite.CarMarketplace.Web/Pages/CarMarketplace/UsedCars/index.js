$(function () {
    var $getUsedCarsForm = $('#get-used-cars-form');        //获取车型数据的表单
    var $PriceRangesSelect = $('#PriceRangesSelect');       //价格区间
    var $MileageRangesSelect = $('#MileageRangesSelect');   //里程区间
    var $PopularTagSelect = $('#PopularTagSelect');         //热门标签
    var $SortingSelect = $('#SortingSelect');               //排序方式



    //选择热门标签
    $PopularTagSelect.change(function () {
        var value = this.value;
        if (value == "") {
            window.location.href = "?tagName=";
        }
        else {
            window.location.href = "?tagName=" + value;
        }
    });
    
    //选择品牌
    $getUsedCarsForm.find('select[name="brandId"]').change(function () {
        $getUsedCarsForm.submit();
    });

    //选择车型
    $getUsedCarsForm.find('select[name="modelId"]').change(function () {
        $getUsedCarsForm.submit();
    });

    //选择车型级别
    $PriceRangesSelect.change(function () {
        var value = this.value;
        var minPrice = value.split('-')[0];
        var maxPrice = value.split('-')[1];
        $getUsedCarsForm.find('input[name="minPrice"]').val(minPrice);
        $getUsedCarsForm.find('input[name="maxPrice"]').val(maxPrice);
        $getUsedCarsForm.submit();
    });

    //选择里程
    $MileageRangesSelect.change(function () {
        var value = this.value;
        var minTotalMileage = value.split('-')[0];
        var maxTotalMileage = value.split('-')[1];
        $getUsedCarsForm.find('input[name="minTotalMileage"]').val(minTotalMileage);
        $getUsedCarsForm.find('input[name="maxTotalMileage"]').val(maxTotalMileage);
        $getUsedCarsForm.submit();
    });

    //选择车型级别
    $getUsedCarsForm.find('select[name="modelLevel"]').change(function () {
        $getUsedCarsForm.submit();
    });

    //选择颜色
    $getUsedCarsForm.find('select[name="color"]').change(function () {
        $getUsedCarsForm.submit();
    });

    //选择排序方式
    $SortingSelect.change(function () {
        var value = this.value;
        window.location.href = changeURLArg("sorting", value);
    });

    //修改url参数的方法
    function changeURLArg(arg, arg_val) {
        var url = window.location.href;
        var pattern = arg + '=([^&]*)';
        var replaceText = arg + '=' + arg_val;
        if (url.match(pattern)) {
            var tmp = '/(' + arg + '=)([^&]*)/gi';
            tmp = url.replace(eval(tmp), replaceText);
            return tmp;
        } else {
            if (url.match('[\?]')) {
                return url + '&' + replaceText;
            } else {
                return url + '?' + replaceText;
            }
        }

        return url;
    }
});