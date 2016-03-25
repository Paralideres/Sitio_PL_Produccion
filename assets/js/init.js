// PL Code
// var guidersConfig = {
//   showOn: [
//     'Secciones.aspx',
//     'VerArticulo.aspx',
//     'Cursos.aspx',
//     'Tag.aspx',
//     'Search.aspx'
//   ]
// };


$(document).ready(function(){
  var ytcChannel = new YTChannel({
      channel: 'UCOAWOfEzQWelgJCihsRmqBg',
      apiKey: 'AIzaSyDzUNwkX6fabVfPtV5epVfQn6QV9r_aFLA',
      maxResults: 1
    }),
    YTChannelCallback = function() {
      ytcChannel.renderSuscribe();
    };

  $(function() {
    $('#tabs').tabs();
  });

  $('.bxslider').bxSlider({
    auto: true,
    mode: 'fade',
    pause: 6000
  });

  // Make sure its attached to the window object
  window.ytcChannel = ytcChannel;
  window.YTChannelCallback = YTChannelCallback;
  ytcChannel.fetchFeed();

  // Remove the modal with the suscribe message
  // initGuiders();
});

  // Remove the modal with the suscribe message
// var initGuiders = function() {
//   var register = $('#ctl00_lblReg').length,
//     contribute = $('#ctl00_ContenidoCentral_Titulo').length,
//     current = window.location.pathname.split('/')[1] || '',
//     showGuider = $.inArray(current, guidersConfig.showOn),
//     cookie = $.cookie('st');

//   if (showGuider && +cookie !== 0) {
//     if (!contribute) {
//       guiders.createGuider({
//         attachTo: '#ctl00_ContenidoInicial_Img2',
//         buttons: [
//           {
//             name: register ? 'Registrarme' : 'Empezar a Colaborar',
//             onclick: function() {
//               if (register) {
//                 window.location = 'Register.aspx';
//               } else {
//                 window.location = 'UploadFile.aspx';
//               }
//             }
//           },
//           {
//             name: 'No mostrar este mensaje',
//             onclick: function() {
//               $.cookie('st', 0, {
//                 expires: 30,
//                 path: '/'
//               });
//               guiders.hideAll();
//             }
//           }
//         ],
//         description: 'Comparte reflexiones, estudios bíblicos, din&aacute;micas, consejos o capacitaciones para el trabajo con j&oacute;venes y adolescentes.',
//         id: 'someId',
//         position: 9,
//         title: 'Participa en ParaL&iacute;deres!',
//         width: 300,
//         offset: {
//           left: -200,
//           top: 13
//         },
//         xButton: true,
//         highlight: true
//       }).show();

//     }
//   }
// };