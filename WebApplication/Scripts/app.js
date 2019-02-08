var ViewModel = function () {
  var self = this;
  self.users = ko.observableArray();
  self.error = ko.observable();
  self.selectedUser = ko.observable();
  self.projects = ko.observableArray();

  this.selectedUser.subscribe(function (latest) {
    ajaxHelper(userProjects + latest.Id, 'GET').done(function (data) {
      self.projects(data);
    });
  }, this);

  var usersUri = '/api/Users/';
  var userProjects = '/api/UserProjects/'
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
  var date = new Date(odate);
  var year = date.getFullYear();
  var month = date.getMonth() + 1;
  var options = { month: 'long' };
  var fullMonth = new Intl.DateTimeFormat('en-US', options).format(date);
  var day = date.getDate();
  return fullMonth + ' ' + day + ', ' + year;
}