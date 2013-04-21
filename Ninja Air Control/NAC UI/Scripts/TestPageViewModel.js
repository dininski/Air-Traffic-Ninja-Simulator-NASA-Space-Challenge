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

    // Applies changes to the position of an airplane
    self.UpdateAirplane = function (newLocation) {
        for (var i = 0; i < self.ActivePlanes().length; i++) {
            if (newLocation.Id == self.ActivePlanes()[i].Id) {
                self.ActivePlanes()[i].X(newLocation.X);
                self.ActivePlanes()[i].Y(newLocation.Y);
                self.ActivePlanes()[i].Z(newLocation.Z);
            }
        }
    }

    // Get the plane's destination display name
    self.GetDestinationName = function (airportId) {
        var result = 'No airport available';
        for (var i = 0; i < self.ActiveAirports().length; i++) {
            if (self.ActiveAirports()[i].Id == airportId) {
                result = self.ActiveAirports()[i].City + ', ' + self.ActiveAirports()[i].Airport;
                break;
            }
        }

        return result;
    }

    // Retrieve Airport object by his Id
    self.GetAirportById = function (airportId) {
        var result = {};
        for (var i = 0; i < self.ActiveAirports().length; i++) {
            if (self.ActiveAirports()[i].Id == airportId) {
                result = self.ActiveAirports()[i];
                break;
            }
        }

        return result
    }
    // -------------------------------------


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
        var activeAirports = JSON.parse(airports);
        self.ActiveAirports(activeAirports);

        var activePlanes = JSON.parse(planes);
        for (var i = 0; i < activePlanes.length; i++) {
            self.ActivePlanes.push({
                Id: activePlanes[i].Identification,
                Speed: activePlanes[i].Speed,
                X: ko.observable(activePlanes[i].X),
                Y: ko.observable(activePlanes[i].Y),
                Z: ko.observable(activePlanes[i].Z),
                Airline: activePlanes[i].Company,
                AirportId: activePlanes[i].Destination,
                Destination: self.GetDestinationName(activePlanes[i].Destination),
                Type: activePlanes[i].Type
            });
        }
    }
    // --------------------------------------


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

        // Line connecting airplane and airport
        ko.bindingHandlers.flightRoute = {
            init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var $element = $(element);
                var planeObj = valueAccessor();

                $element.css('top', planeObj.Y());
                $element.css('left', planeObj.X());

                var airport = self.GetAirportById(planeObj.Destination);

                var length = Math.sqrt((planeObj.X() - airport.X) * (planeObj.X() - airport.X) + (planeObj.Y() - airport.Y) * (planeObj.Y() - airport.Y))
                $element.css('width', length + 'px');

                var angle = Math.atan2(airport.Y - planeObj.Y(), airport.X - planeObj.X()) * 180 / Math.PI;
                $element.css('transform', 'rotate(' + angle + 'deg)');
            },
            update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
                var $element = $(element);
                var planeObj = valueAccessor();

                $element.css('top', planeObj.Y());
                $element.css('left', planeObj.X());
               

                var airport = self.GetAirportById(planeObj.AirportId);
                var adjAirportX = airport.X + 6;
                var adjAirportY = airport.Y + 7;

                var length = Math.sqrt((planeObj.X() - adjAirportX) * (planeObj.X() - adjAirportX) + (planeObj.Y() - adjAirportY) * (planeObj.Y() - adjAirportY))
                $element.css('width', length + 'px');

                var angle = Math.atan2(adjAirportY - planeObj.Y(), adjAirportX - planeObj.X()) * 180 / Math.PI;
                $element.css('transform', 'rotate(' + angle + 'deg)');
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
    // -------------------------------------



    self.Initialize();
})
    (jQuery)