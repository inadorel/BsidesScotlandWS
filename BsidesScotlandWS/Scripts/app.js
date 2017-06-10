var ViewModel = function () {
    var self = this;
    self.sponsors = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();

    var sponsorsUri = '/api/sponsors/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllSponsors() {
        ajaxHelper(sponsorsUri, 'GET').done(function (data) {
            self.sponsors(data);
        });
    }

    
    self.getSponsorDetail = function (item) {
        ajaxHelper(sponsorsUri + item.SponsorId, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.deleteSponsor = function (item) {
        ajaxHelper(sponsorsUri + item.SponsorId, 'DELETE').done(function (data) {
            self.detail(data);
        });
    }

    // Fetch the initial data.
    getAllSponsors();

  
    self.newSponsor = {
    sponsorFirstName: ko.observable(),
    sponsorLastName: ko.observable(),
    sponsorCompanyName: ko.observable(),
    sponsorLevel: ko.observable(),
    sponsorStatus: ko.observable()
           }
    

self.addSponsor = function (formElement) {
    var sponsor = {
        sponsorFirstName: self.newSponsor.sponsorFirstName(),
        sponsorLastName: self.newSponsor.sponsorLastName(),
        sponsorCompanyName: self.newSponsor.sponsorCompanyName(),
        sponsorLevel: self.newSponsor.sponsorLevel(),
        sponsorStatus: self.newSponsor.sponsorStatus()
    };

    var sponsorsUri = '/api/sponsors/';
    ajaxHelper(sponsorsUri, 'POST', sponsor).done(function (item) {
        self.sponsors.push(item);
    });
}

// getSponsors();
};

ko.applyBindings(new ViewModel());