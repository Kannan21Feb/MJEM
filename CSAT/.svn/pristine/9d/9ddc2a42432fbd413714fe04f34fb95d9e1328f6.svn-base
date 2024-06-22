//----------------------------------------------------------------
$(function () {
  if ('speechSynthesis' in window) {
    speechSynthesis.onvoiceschanged = function () {
      var $voicelist = $('#voices');

      if ($voicelist.find('option').length == 0) {
        speechSynthesis.getVoices().forEach(function (voice, index) {
          var $option = $('<option>')
            .val(index)
            .html(voice.name + (voice.default ? ' (default)' : ''));

          $voicelist.append($option);
        });

        //$voicelist.material_select();
      }
    }

    $('#speak').click(function () {
      var text = $('.hidden_span')[0].innerHTML;
      var msg = new SpeechSynthesisUtterance();
      var voices = window.speechSynthesis.getVoices();
      msg.voice = voices[$('#voices').val()];
      msg.rate = 6 / 10;
      msg.pitch = 1;
      msg.text = text;

      msg.onend = function (e) {
        console.log('Finished in ' + event.elapsedTime + ' seconds.');
      };

      speechSynthesis.speak(msg);
    })
  } else {
    alert('error');
  }
});
//---------------------


$(document).ready(function () {

  captchaCatcher();
  $('.visualCaptcha-refresh-button').click(captchaCatcher);
  $('.visualCaptcha-possibilities a').click(titleCatcher);
  $('#check-is-filled').click(submitter);
  $('.visualCaptcha-accessibility-button').click(audioFieldChecker);
  $('.visualCaptcha-accessibility-wrapper').hide();
  $('.visualCaptcha-possibilities .img').click(selectImage);
})

//global variables / flags
var flag = false;
var audioflag = false;
var audio = '';

function selectImage() {
  $('.visualCaptcha-possibilities .img').each(function () {
    $(this).removeClass('selectImage visualCaptcha-selected');
  });
  $(this).addClass('selectImage visualCaptcha-selected');
}

function captchaCatcher() {
  $('.visualCaptcha-possibilities').empty();
  var images = ['images/captcha/ambulance.svg', 'images/captcha/camera.svg', 'images/captcha/cloud.svg', 'images/captcha/flag.svg', 'images/captcha/gift.svg', 'images/captcha/hospital.svg', 'images/captcha/key.svg', 'images/captcha/leaf.svg', 'images/captcha/phone.svg', 'images/captcha/trophy.svg', 'images/captcha/truck.svg'];
  var title = ['ambulance', 'camera', 'cloud', 'flag', 'gift', 'hospital', 'key', 'leaf', 'phone', 'trophy', 'truck'];
  var index = 0;

  var item = parseInt([Math.floor(Math.random() * images.length)]);
  var ranger = parseInt([Math.floor(Math.random() * 5)]);


  if (item < images.length - 5) {
    item = item;
    $('.verification_name')[0].innerText = title[item + ranger];
  }
  else {
    item = item - 5;
    $('.verification_name')[0].innerText = title[item + ranger];
  }
  var imagesSliced = images.slice(item, item + 5);
  var titleSliced = title.slice(item, item + 5);
  for (index = 0; index < 5; index++) {
      $('.visualCaptcha-possibilities').append('<div class="img"><a href="javascript:void(0)"><img src="../' + imagesSliced[index] + '" id="visualCaptcha-img-' + index + '" data-index="0" alt="" data-title="' + titleSliced[index] + '"></a></div>');
  }


  audio = parseInt([Math.floor(Math.random() * 99)]);
  if (audio < 10) {
    audio = audio + 10;
  }
  else {
    audio = audio;
  }

  $('.hidden_span')[0].innerHTML = audio.toString();
  $('#message').val('');
  if (audioflag) {
    setTimeout(function () {
      $('#speak').trigger('click');
    }, 300);
  }

}



function titleCatcher() {

  var checker = $(this).find('img').attr('data-title');
  var givenName = $('.verification_name')[0].innerText;
  if (givenName == checker) {
    flag = true;
  }
  else {
    flag = false;
  }
}



function audioFieldChecker() {

  audioflag = !audioflag;
  flag = false;
  audio = parseInt([Math.floor(Math.random() * 99)]);
  if (audio < 10) {
    audio = audio + 10;
  }
  else {
    audio = audio;
  }
  $('.hidden_span')[0].innerHTML = audio.toString();

  if (audioflag) {
    $('.visualCaptcha-explanation').hide();
    $('.visualCaptcha-possibilities').hide();
    $('.visualCaptcha-accessibility-wrapper').show();
    setTimeout(function () {
      $('#speak').trigger('click');
    }, 300);
    $('.visualCaptcha-button-group').addClass('unique_audio_group');
  }
  else {
    $('.visualCaptcha-explanation').show();
    $('.visualCaptcha-possibilities').show();
    $('.visualCaptcha-accessibility-wrapper').hide();
    $('.visualCaptcha-button-group').removeClass('unique_audio_group');
  }

}



function submitter() {
    var _bool = false;
  var audioField = $('#message').val();
  if (audioflag == true && (audioField != undefined && audioField == audio)) {
    audioflag = true;
  }
  else if (audioField != undefined && audioField == audio) {
    audioflag = true;
  }
  else {
    audioflag = false;
  }


  if (flag && !audioflag) {
      //alert('matched');
      _bool = true;
  }
  else if (!flag && audioflag) {
      _bool = true;// alert('text matched');
  }
  else if (!flag && !audioflag) {
    alert('wrong captcha/text not entered');
    }
    return _bool;
}