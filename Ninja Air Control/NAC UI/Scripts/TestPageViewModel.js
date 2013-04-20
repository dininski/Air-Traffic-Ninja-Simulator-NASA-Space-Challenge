(function ($, undefined) {

    // self is the reference point of the View Model object
    var self = {};
        
    self.UpdateHub = $.connection.realTimeUpdateHub; // Initialize the signalr update hub
    self.ActivePlanes = ko.observableArray([]); // Container for the active plaines

    // ---------- Utility methods ----------
    self.GetPosition = function (plane) {
        return 'X: ' + plane.X() + ' , Y: ' + plane.Y();
    }

    // ---------- SignalR methods ----------
    // The javascript method called by the SignalR hub for updating plane location
    self.UpdateHub.client.updateCoordinates = function (newLocation) {
        var location = JSON.parse(newLocation);
        self.ActivePlanes()[0].X(location.X);
        self.ActivePlanes()[0].Y(location.Y);
    }


    // ---------- Loading and initialization ----------
    // Initialize custom knockout bindings to the ko object namespace    
    self.InitiCustomBindings = function () {
        ko.bindingHandlers.planePosition = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                debugger;
                var $element = $(element);
                var planeObj = valueAccessor();
                $element.offset({
                    left: planeObj.X(),
                    top: planeObj.Y()
                });

                $element.attr('title', planeObj.Airline + ' flying to ' + planeObj.Destination + '. X:' + planeObj.X() + ' Y:' + planeObj.Y());
                

            },
            update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var $element = $(element);
                var planeObj = valueAccessor();
                $element.offset({
                    left: planeObj.X(),
                    top: planeObj.Y()
                });

                $element.attr('title', planeObj.Airline + ' flying to ' + planeObj.Destination + '. X:' + planeObj.X() + ' Y:' + planeObj.Y());
            }
        };
    }

    // Run setup and initialization
    self.Initialize = function () {

        self.InitiCustomBindings();

        self.ActivePlanes.push({
            X: ko.observable(300),
            Y: ko.observable(200),
            Airline: 'Pacific Airlines',
            Destination: 'Chicago'
        });

        ko.applyBindings(self);

        $.connection.hub.start(); // Open connection
    }

    self.Initialize();
})
    (jQuery)