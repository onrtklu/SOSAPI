(function () {

    var _token = "";

    function getJwt(loginData, success, error, complete) {
        $.ajax({
            url: loginData.path,
            type: 'POST',
            data: {
                grant_type: 'password',
                username: loginData.user,
                password: loginData.pass

            },
            success: function (data) {
                _token = data.access_token;
                success && success(data.access_token);
            },
            error: function (jqXhr, err, msg) {
                error && error(JSON.parse(jqXhr.responseText).error_description);

            },
            complete: complete
        });
    }

    function setJwt(key) {
        swaggerUi.api.clientAuthorizations.authz = {};
        swaggerUi.api.clientAuthorizations.add("key", new SwaggerClient.ApiKeyAuthorization("Authorization", "Bearer " + key, "header"));

    }


    $(function () {


        (function () {
            var styles = `
                <style>
                #sa-setting{
                    display:inline-block;
                    position: absolute;
                    background: #89BF04;
                    right: 20px;
                    top: 48px;
                    padding: 10px;
                    box-shadow: 0 2px 1px rgba(0,0,0,0.5);
                    display: none;
                    z-index: 1;
                }

                #sa-qr-code{
                    display:inline-block;
                    position: absolute;
                    background: #FFFFFF;
                    right: 20px;
                    top: 48px;
                    padding: 10px;
                    box-shadow: 0 2px 1px rgba(0,0,0,0.5);
                    display: none;
                }
                #sa-profile-picture{
                    display:inline-block;
                    position: absolute;
                    background: #FFFFFF;
                    right: 20px;
                    top: 48px;
                    padding: 10px;
                    box-shadow: 0 2px 1px rgba(0,0,0,0.5);
                    display: none;
                    z-index: 1;
                }

                 .sa-btn{
                    display: inline-block;
                    color: #FFF;
                    font-weight: bold;
                    background: #547F00;
                    border-radius: 3px;
                    padding: 6px 8px;
                    font-family: "Droid Sans", sans-serif;
                    font-size: 0.9em;
                    cursor: pointer;
                }

                 .sa-btn-qr-code{
                    display: inline-block;
                    color: #FFF;
                    font-weight: bold;
                    background: #000000;
                    border-radius: 3px;
                    padding: 6px 8px;
                    font-family: "Droid Sans", sans-serif;
                    font-size: 0.9em;
                    cursor: pointer;
                }

                 .sa-btn-profile-picture{
                    display: inline-block;
                    color: #FFF;
                    font-weight: bold;
                    background: #6b2314;
                    border-radius: 3px;
                    padding: 6px 8px;
                    font-family: "Droid Sans", sans-serif;
                    font-size: 0.9em;
                    cursor: pointer;
                }

                #sa-setting input{
                    margin-bottom: 5px;
                    padding: 3px;
                    border: 2px inset;
                }
                .img-qr-code{
                    width: 200px;
                }

                .tooltip {
                  position: relative;
                  display: inline-block;
                  border-bottom: 1px dotted black;
                }

                .tooltip .tooltiptext {
                  visibility: hidden;
                  width: 100%;
                  background-color: #555;
                  color: #fff;
                  text-align: center;
                  border-radius: 6px;
                  padding: 5px 0;
                  position: absolute;
                  z-index: 1;
                  bottom: 95%;
                  left: 30%;
                  margin-left: -60px;
                  opacity: 0;
                  transition: opacity 0.3s;
                }

                .tooltip .tooltiptext::after {
                  content: "";
                  position: absolute;
                  top: 100%;
                  left: 50%;
                  margin-left: -5px;
                  border-width: 5px;
                  border-style: solid;
                  border-color: #555 transparent transparent transparent;
                }

                .tooltip:hover .tooltiptext {
                  visibility: visible;
                  opacity: 1;
                }

            </style>
            `;
            $('head').append(styles);
            var settingTemplate = `

                <div id="sa-qr-code">
                    <div class="tooltip">
                        <img src="/Upload/QRCode/QRCode 1-1.png" class="img-qr-code"/>
                        <span class="tooltiptext">QRCodeRestaurantId: 1 QRCodeTableId: 1</span>
                    </div>
                    <div class="tooltip">
                        <img src="/Upload/QRCode/QRCode 1-2.png" class="img-qr-code"/>
                        <span class="tooltiptext">QRCodeRestaurantId: 1 QRCodeTableId: 2</span>
                    </div>
                    <div class="tooltip">
                        <img src="/Upload/QRCode/QRCode 2-3.png" class="img-qr-code"/>
                        <span class="tooltiptext">QRCodeRestaurantId: 2 QRCodeTableId: 3</span>
                    </div>
                </div>

                <div id="sa-setting">
                    <input id="sa-path" placeholder="Path" value="/api/token">
                    <br>
                    <input id="sa-username" placeholder="Email">
                    <br>
                    <input id="sa-password" type="password" placeholder="Password">
                    <br>
                    <span id="sa-btn-login" class="sa-btn">Login</span>
                    <span id="sa-btn-logout" class="sa-btn" style="display: none">Logout</span>
                </div>


                <div id="sa-profile-picture">
                    <input id="sa-path-verb" placeholder="Http Verb" value="PUT">
                    <br>
                    <input id="sa-path-picture" placeholder="Path" value="/api/customer/upload-profile-picture">
                    <br>
                    <input type="file" id="imageFile"/>
                    <br>
                    <span id="sa-btn-upload-image" class="sa-btn">Upload Image</span>
                    <br>
                    <label id="sa-profile-picture-response" style="color: #7f0029;font-weight: bold;"></label>
                </div>

            `;
            $('body').append(settingTemplate);



            $('<div id="sa-btn-setting" class="sa-btn">Login</div>')
                .click(function () {
                    $('#sa-setting').fadeToggle();
                })
                .appendTo('#api_selector');


            $('<div id="sa-btn-qr-code" class="sa-btn-qr-code">QR Code</div>')
                .click(function () {
                    $('#sa-qr-code').fadeToggle();
                })
                .appendTo('#api_selector');


            $('<div id="sa-btn-profile-picture" class="sa-btn-profile-picture">Upload Image</div>')
                .click(function () {
                    $('#sa-profile-picture').fadeToggle();
                })
                .appendTo('#api_selector');

        })();


        function login(loginData) {
            $('#sa-btn-setting').text('Working...');
            getJwt(loginData,
                function (jwt) {
                    $('#sa-btn-setting').text('Hi ' + loginData.user).css('background', '#0f6ab4');
                    $('#sa-setting').fadeOut();
                    $('#sa-btn-logout').fadeIn();
                    setJwt(jwt);
                },
                function (err) {
                    $('#sa-btn-setting').text('Failed').css('background', '#a41e22');

                    setJwt('');
                    alert(err);
                }, function () {
                    // $('#sa-btn-setting').text('Login');

                });
        }

        $('#sa-btn-logout').click(function () {
            setJwt('');
            window.localStorage.removeItem('sa-login-data');
            $('#sa-username').val('');
            $('#sa-password').val('');
            $(this).fadeOut();
        });

        $('#sa-btn-login').click(function () {


            var loginData = {
                path: $('#sa-path').val(),
                user: $('#sa-username').val(),
                pass: $('#sa-password').val()
            };
            window.localStorage.setItem('sa-login-data', JSON.stringify(loginData));

            login(loginData);


        });



        $('#sa-btn-upload-image').click(function () {

            var file = document.getElementById("imageFile").files[0];
            var r = new FileReader();
            r.onloadend = function (e) {

                var arr = Array.from(new Uint8Array(e.target.result));

                var uploadData = {
                    ProfilePicture: arr
                };
                console.log(uploadData);

                $.ajax({
                    type: $('#sa-path-verb').val(), // "PUT",
                    headers: { "Authorization": "Bearer " + _token },
                    url: $('#sa-path-picture').val(), // "/api/customer",
                    data: uploadData,
                    success: function (response) {
                        console.log(response);
                        alert("success");
                        //$('#sa-profile-picture-response').html('success');
                    },
                    error: function (error) {
                        console.log("HATA - " + error.responseText);
                        alert(error.responseText);
                        //$('#sa-profile-picture-response').html(error.responseText);
                    }
                });

            };
            r.readAsArrayBuffer(file);

        });

        //Auto login
        (function () {
            var oldLoginData = window.localStorage.getItem('sa-login-data');
            if (oldLoginData) {
                oldLoginData = JSON.parse(oldLoginData);
                $('#sa-path').val(oldLoginData.path);
                $('#sa-username').val(oldLoginData.user);
                $('#sa-password').val(oldLoginData.pass);
                login(oldLoginData);
            }

        })();

    });
})();