(function () {
            try {

                $("#newGarage").submit(function (event) {
                    event.preventDefault();//prevents refresh

                    var j = { "name": $("#name").val() };
                    var js = JSON.stringify(j);

                    $.ajax(
                        {
                            url: "https://localhost:7195/api/Garages",
                            type: 'POST',
                            data: js,
                            dataType: "json",
                            contentType: "application/json",
                            success: function (response) {
                                $("#Garages").append('<li>' + response.name + '(' + response.garageId + ')' +
                                    "  <button type='button' class= 'edit' >&#9998</button>" +
                                    "  <button type='button' class= 'delete' >&#128465</button>"
                                    + '</li>');
                            },
                            error: function (xhr, status, error) {
                                alert('Your form was not sent successfully.');
                            }
                        });
                });

                $("#newWorker").submit(function (event) {
                    event.preventDefault();//prevents refresh
                    
                    var j = { "workerName": $("#workerName").val() };
                    var js = JSON.stringify(j);
                    
                    $.ajax({
                        url: "https://localhost:7195/api/Workers",
                        type: 'POST',
                        data: js,
                        dataType: "json",
                        contentType: "application/json",
                        success: function (response) {
                            $("#Workers").append('<li>' + response.workerName + '(' + response.workerId + ')' +
                                "  <button type='button' class= 'edit'>&#9998</button>" +
                                
                                + '</li>');
                        },
                        error: function (xhr, status, error) {
                            alert('Your form was not sent successfully.');
                        }
                    });
                });

                $.ajax({
                    url: "https://localhost:7195/api/Workers",
                    type: "GET",
                    success: function (data) {
                        for (const elem of data) {
                            $("#Workers").append('<li>' + elem.workerName + '(' + elem.workerId + ')' +
                                "  <button type='button' class= 'edit'>&#9998</button>" +
                                "  <button type='button' class= 'delete'>&#128465</button>"
                                + '</li>');
                        }
                    }
                });

                $.ajax(
                    {
                        url: "https://localhost:7195/api/Garages",
                        type: "GET",
                        success: function (data) {
                            for (const elem of data) {
                                $("#Garages ol").append('<li>' + elem.name + '(' + elem.garageId + ')' +
                                    "  <button type='button' class= 'edit'>&#9998</button>" +
                                    "  <button type='button' class= 'delete'>&#128465</button>"
                                    + '</li>');
                            }

                            $(".delete").click(function (event) {
                                var gid = this.id;

                                $.ajax(
                                    {
                                        url: "https://localhost:7195/api/Garages/" + gid,
                                        type: 'DELETE',
                                        success: function (response) {
                                            alert("deleted");

                                        },
                                        error: function (xhr, status, error) {
                                            alert('not deleted');
                                        }
                                    });

                            });

                            $(".edit").click(function (event) {
                                var gid = this.id;
                                debugger
                                $(this).parent().append(
                                    '<form id = edit' + this.id + ' class="edited">' +
                                    '<input type="text" id="nameEdit" required />' +
                                    '<input type="submit" id="editGarage" value="Edit!" />' +
                                    '</form>'
                                );

                                $("#edit" + this.id).submit(function (event) {

                                    var j = { "name": $("#nameEdit").val() };
                                    var js = JSON.stringify(j);

                                    $.ajax(
                                        {
                                            url: "https://localhost:7195/api/Garages/" + gid,
                                            type: 'PUT',
                                            data: js,
                                            dataType: "json",
                                            contentType: "application/json",
                                            success: function (response) {
                                                $("#Garages").append('<li>' + response.name + '(' + response.garageId + ')' + '</li>');
                                            },
                                            error: function (xhr, status, error) {
                                                alert('Your form was not sent successfully.');
                                            }
                                        });

                                });
                            });
                        },
                        error: function () {
                            console.log("https://localhost:7195/api/Garages NA");
                        }

                    });


            }
            catch (ex) {
                console.log(ex);
            }

        })();