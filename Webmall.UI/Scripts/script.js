/*
**	Author: Vladimir Shevchenko
**	URI: http://www.howtomake.com.ua/2012/stilizaciya-vsex-elementov-form-s-pomoshhyu-css-i-jquery.html 
*/
$(document).ready(function () {
	
    $(function() {

        function calcCrow(lat1, lon1, lat2, lon2) {
            var R = 6371; // km
            var dLat = toRad(lat2 - lat1);
            var dLon = toRad(lon2 - lon1);
            var lat1 = toRad(lat1);
            var lat2 = toRad(lat2);

            var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
                Math.sin(dLon / 2) * Math.sin(dLon / 2) * Math.cos(lat1) * Math.cos(lat2);
            var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
            var d = R * c;
            return d;
        }

        function toRad(Value) {
            return Value * Math.PI / 180;
        }

        $.post(
			linkGetCitys,
            function(data) {
                console.log(data, " - GetCitys")

				function success(pos) {
                    var crd = pos.coords;
                    var cityauto = {
                        id: "",
						distans: 0,
						shortname: ""
                    };

                    $.each(data.citys,
                        function(i, item) {
                            distans = calcCrow(crd.latitude, crd.longitude, item.Lat, item.Lot).toFixed(5) * 1000;
                            if (cityauto.distans == 0) {
                                cityauto.distans = distans;
								cityauto.id = item.Id;
                                cityauto.shortname = item.ShortName;
                            }
                            if (distans < cityauto.distans) {
                                cityauto.distans = distans;
								cityauto.id = item.Id;
                                cityauto.shortname = item.ShortName;
                            }
                        });
					SetCity(cityauto.id+"", cityauto.shortname);
					$("#informer-caption").text(identifiedStoreClosest+", \"" + cityauto.shortname +"\"");
					$("#informer-desc").text(chooseAnotherDeliveryPoint);
					$('.top-informer').removeAttr('hidden');
                }
                function error(err) {
					$("#informer-caption").text(deniedAccessGeodata);
					$("#informer-desc").text(deliveryPoint);
					$('.top-informer').removeAttr('hidden');
				}

                $.each(data.citys,
                    function(i, item) {
						$("#locations-list").append('<li class="modal-content__location-item"><a class="modal-content__location-link" href = "javascript:void(0);" onclick="SetCity( \'' + item.Id + '\', \'' + item.ShortName + '\');">' + item.Name + '</a></li>');
						$("#mob-locations-list").append('<li class="mob-regions__item"><a class="mob-regions__region" href="javascript:void(0);" onclick="SetCity(\'' + item.Id + '\', \'' + item.ShortName + '\');">' + item.Name + '</a></li>');
                    }
				);

				if ($.cookie("CityId")) {
					$.each(data.citys, function (i, item) {
						if (item.Id == $.cookie("CityId")) {
							$("#current-location").text(item.ShortName);
                        }
                    })
                    
                } else {
                    navigator.geolocation.getCurrentPosition(success, error);
                }
				
            });


    });

    //Reset form
	// Вешаем событие клика по кнопке сброса
	//$('.reset-form').click(function() {
	//	// Устанавливаем пустое значение в атрибут value для всех инпутов
	//	$('.customForm').find('input').val('');
		
	//	// Убираем атрибут checked и класс активности у чекбоксов
	//	$('.customForm').find('input:checked').removeAttr('checked');
	//	$('.customForm').find('.check').removeClass('active');
		
	//	// Убираем класс активности у радио переключателей
	//	$('.customForm').find('.radio').removeClass('active');
		
	//	// Устанавливаем пустое значение в атрибут value для всех textarea
	//	$('.customForm').find('textarea').val('');
		
	//	// И для открывалки селекта возвращаем начальное значение
	//	$('.customForm').find('.slct').html('Выберите Ваше лучшее качество:');
	//});
	
	//// = Load
	//// отслеживаем изменение инпута file
	//$('#file').change(function(){
	//	// Если файл прикрепили то заносим значение value в переменную
	//	var fileResult = $(this).val();
	//	// И дальше передаем значение в инпут который под загрузчиком
	//	$(this).parent().find('.fileLoad').find('input').val(fileResult);
	//});

	///* Добавляем новый класс кнопке если инпут файл получил фокус */
	//$('#file').hover(function(){
	//	$(this).parent().find('button').addClass('button-hover');
	//}, function(){
	//	$(this).parent().find('button').removeClass('button-hover');
	//});
	
	// Checkbox
	// Отслеживаем событие клика по диву с классом check
	//$('.checkboxes').find('.check').click(function(){
	//	// Пишем условие: если вложенный в див чекбокс отмечен
	//	if( $(this).find('input').is(':checked') ) {
	//		// то снимаем активность с дива
	//		$(this).removeClass('active');
	//		// и удаляем атрибут checked (делаем чекбокс не отмеченным)
	//		$(this).find('input').removeAttr('checked');
		
	//	// если же чекбокс не отмечен, то
	//	} else {
	//		// добавляем класс активности диву
	//		$(this).addClass('active');
	//		// добавляем атрибут checked чекбоксу
	//		$(this).find('input').attr('checked', true);
	//	}
	//});
		
	// Select
	$('.slct').click(function(){
		/* Заносим выпадающий список в переменную */
		var dropBlock = $(this).parent().find('.drop');
		
		/* Делаем проверку: Если выпадающий блок скрыт то делаем его видимым*/
		if( dropBlock.is(':hidden') ) {
			dropBlock.slideDown();
			
			/* Выделяем ссылку открывающую select */
			$(this).addClass('active');
			
			/* Работаем с событием клика по элементам выпадающего списка */
			$('.drop').find('li').click(function(){
				
				/* Заносим в переменную HTML код элемента 
				списка по которому кликнули */
				var selectResult = $(this).html();
				
				/* Находим наш скрытый инпут и передаем в него 
				значение из переменной selectResult */
				$(this).parent().parent().find('input').val(selectResult);
				
				/* Передаем значение переменной selectResult в ссылку которая 
				открывает наш выпадающий список и удаляем активность */
				$('.slct').removeClass('active').html(selectResult);
				
				/* Скрываем выпадающий блок */
				dropBlock.slideUp();
			});
			
		/* Продолжаем проверку: Если выпадающий блок не скрыт то скрываем его */
		} else {
			$(this).removeClass('active');
			dropBlock.slideUp();
		}
		
		/* Предотвращаем обычное поведение ссылки при клике */
		return false;
	});	
		
	// RadioButton
	//$('.radioblock').find('.radio').click(function(){
	//	var valueRadio = $(this).html();
	//	$(this).parent().find('.radio').removeClass('active');
	//	$(this).addClass('active');
	//	$(this).parent().find('input').val(valueRadio);
	//});

	// handler auto closes UI Dialog's (jqQuery) in case when user will click on .ui-widget-overlay 
	$('body').on('click', '.ui-widget-overlay', function() {
		$(".ui-dialog-content").dialog('close');
	});
	$(document).ready(function () {
		$(function () {
			$("#auth-form-mob").validate({
				rules: {
					UserName: {
						required: true
					},
					Pass: {
						required: true
					}
				}
			});
		});

	});
});