var ViewModel = function () {
  var self = this;
  self.users = ko.observableArray();
  self.error = ko.observable();
  self.selectedUser = ko.observable();
  self.projects = ko.observableArray();

  this.selectedUser.subscribe(function (latest) {
    selectedUser = latest;
    if (latest != null) {
      self.projects(latest.UserProjects);
    }
    else {
      self.projects(ko.observableArray());
    }
    ko.applyBindings(self);
  }, this);

  var usersUri = '/api/Users/';

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

  function getAllUsers() {
    ajaxHelper(usersUri, 'GET').done(function (data) {
      self.users(data);
    });
  }

  // Fetch the initial data.
  getAllUsers();
};

ko.applyBindings(new ViewModel());

function formatDate(odate) {
  return moment(odate).format('MMM DD, YYYY h:mm:ss a');
}

function calcAssignedDate(start, assigned) {
  var startDate = new Date(start);
  var assignedDate = new Date(assigned);

  var diff = startDate - assignedDate;

  if (diff < 0) {
    return "Started";
  }
  else {
    var time = new moment.duration(diff);
    var str = Math.floor(time.asDays()) + " days and ";

    var leftOverTime = time.asHours() % 24;

    if (leftOverTime != 0) {
      str += leftOverTime + " hours";
    }
    return str;
  }
}

function getActiveState(active) {
  if (active) {
    return "Active";
  }
  else {
    return "Inactive";
  }
}