(function ($, undefined) {
    'use strict'
    // self is the reference point of the View Model object
    var self = {};

    self.UpdateHub = $.connection.realTimeUpdateHub; // Initialize the signalr update hub
    self.ActivePlanes = ko.observableArray([]); // Container for the active plaines
    self.ActiveAirports = ko.observableArray([]); // Container for the active airports

    // ---------- Utility methods ----------
    self.GetPosition = function (plane) {
        return 'X: ' + plane.X() + ' , Y: ' + plane.Y();
    }

    self.UpdateAirplane = function (newLocation) {
        for (var i = 0; i < self.ActivePlanes().length; i++) {
            if (newLocation.Id == self.ActivePlanes()[i].Id) {
                self.ActivePlanes()[i].X(newLocation.X);
                self.ActivePlanes()[i].Y(newLocation.Y);
                self.ActivePlanes()[i].Z(newLocation.Z);
            }
        }
    }


    // ---------- SignalR methods ----------
    // The javascript method called by the SignalR hub for updating plane location
    self.UpdateHub.client.updateCoordinates = function (newLocation) {
        var newLocations = JSON.parse(newLocation);
        for (var i = 0; i < newLocations.length; i++) {
            self.UpdateAirplane(newLocations[i]);
        }
    }

    // Load Initial data for airplanes
    self.UpdateHub.client.LoadActivePlanesAndAirports = function (planes, airports) {
        var activePlanes = JSON.parse(planes);
        for (var i = 0; i < activePlanes.length; i++) {
            self.ActivePlanes.push({
                Id : activePlanes[i].Identification,
                Speed : activePlanes[i].Speed,
                X : ko.observable(activePlanes[i].X),
                Y : ko.observable(activePlanes[i].Y),
                Z : ko.observable(activePlanes[i].Z),
                Airline : activePlanes[i].Company,
                Destination : activePlanes[i].Destination,
                Type: activePlanes[i].Type
            });
        }

        var activeAirports = JSON.parse(airports);
        self.ActiveAirports(activeAirports);
    }

    // ---------- Loading and initialization ----------
    // Initialize custom knockout bindings to the ko object namespace    
    self.InitiCustomBindings = function () {

        // Plane position binding
        ko.bindingHandlers.planePosition = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var $element = $(element);
                var planeObj = valueAccessor();

                $element.css('top', planeObj.Y());
                $element.css('left', planeObj.X());

                $element.attr('title', planeObj.Airline + ' flying to ' + planeObj.Destination + '. X:' + planeObj.X() + ' Y:' + planeObj.Y());


            },
            update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var $element = $(element);
                var planeObj = valueAccessor();

                $element.css('top', planeObj.Y());
                $element.css('left', planeObj.X());

                $element.attr('title', planeObj.Airline + ' flying to ' + planeObj.Destination + '. X:' + planeObj.X() + ' Y:' + planeObj.Y());
            }
        };

        // Airport position binding
        ko.bindingHandlers.airportPosition = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var $element = $(element);
                var airportObj = valueAccessor();

                $element.css('top', airportObj.Y - 34);
                $element.css('left', airportObj.X - 13);

                $element.attr('title', airportObj.City + ', ' + airportObj.Airport);
            },
            update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
            }
        };
    }

    self.LoadActivePlanes = function () {
        self.UpdateHub.server.loadActivePlanes();
    }

    // Run setup and initialization
    self.Initialize = function () {

        self.InitiCustomBindings();

        ko.applyBindings(self);

        $.connection.hub.start().done(self.LoadActivePlanes); // Open connection and load active planes
    }

    self.Initialize();
})
    (jQuery)