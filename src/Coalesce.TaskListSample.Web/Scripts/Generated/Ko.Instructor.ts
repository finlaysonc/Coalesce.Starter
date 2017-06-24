
/// <reference path="../coalesce.dependencies.d.ts" />

// Knockout View Model for: Instructor
// Auto Generated by IntelliTect.Coalesce

module ViewModels {

	export class Instructor extends Coalesce.BaseViewModel<Instructor>
    {
        protected modelName = "Instructor";
        protected primaryKeyName = "instructorId";
        protected modelDisplayName = "Instructor";

        protected apiController = "/Instructor";
        protected viewController = "/Instructor";
        public dataSources = ListViewModels.InstructorDataSources;


        // The custom code to run in order to pull the initial datasource to use for the object that should be returned
        public dataSource: ListViewModels.InstructorDataSources = ListViewModels.InstructorDataSources.Default;

        public static coalesceConfig
            = new Coalesce.ViewModelConfiguration<Instructor>(Coalesce.GlobalConfiguration.viewModel);
        public coalesceConfig: Coalesce.ViewModelConfiguration<Instructor>
            = new Coalesce.ViewModelConfiguration<Instructor>(Instructor.coalesceConfig);
    
        // Observables
        public instructorId: KnockoutObservable<number> = ko.observable(null);
        public hireDate: KnockoutObservable<moment.Moment> = ko.observable(moment());
        public lastName: KnockoutObservable<string> = ko.observable(null);
        public firstName: KnockoutObservable<string> = ko.observable(null);
        public fullName: KnockoutObservable<string> = ko.observable(null);

       
        // Create computeds for display for objects
        

                // Pops up a stock editor for this object.



        
        public originalData: KnockoutObservable<any> = ko.observable(null);
        
        // This method gets called during the constructor. This allows injecting new methods into the class that use the self variable.
        public init(myself: Instructor) {};

        constructor(newItem?: any, parent?: any){
            super();
            var self = this;
            self.parent = parent;
            self.myId;
            // Call an init function that allows for proper inheritance.
            if ($.isFunction(self.init)){
                self.init(self);
            }
            
            ko.validation.init({
                grouping: {
                    deep: true,
                    live: true,
                    observable: true
                }
            });

            // SetupValidation {
			self.hireDate = self.hireDate.extend({ moment: { unix: true },  });
			self.lastName = self.lastName.extend({ required: {params: true, message: "Last Name is required."} });
			self.firstName = self.firstName.extend({ required: {params: true, message: "First Name is required."} });
            
            self.errors = ko.validation.group([
                self.instructorId,
                self.hireDate,
                self.lastName,
                self.firstName,
                self.fullName,
            ]);
            self.warnings = ko.validation.group([
            ]);

            // Computed Observable for edit URL
            self.editUrl = ko.computed(function() {
                return self.coalesceConfig.baseViewUrl() + self.viewController + "/CreateEdit?id=" + self.instructorId();
            });

            // Create computeds for display for objects


            // Load the ViewModel object from the DTO. 
            // Force: Will override the check against isLoading that is done to prevent recursion. False is default.
            // AllowCollectionDeletes: Set true when entire collections are loaded. True is the default. In some cases only a partial collection is returned, set to false to only add/update collections.
			self.loadFromDto = function(data: any, force: boolean = false, allowCollectionDeletes: boolean = true) {
				if (!data || (!force && self.isLoading())) return;
				self.isLoading(true);
				// Set the ID 
				self.myId = data.instructorId;
				self.instructorId(data.instructorId);
				// Load the lists of other objects
				// Objects are loaded first so that they are available when the IDs get loaded.
				// This handles the issue with populating select lists with correct data because we now have the object.

				// The rest of the objects are loaded now.
                if (data.hireDate == null) self.hireDate(null);
				else if (self.hireDate() == null || !self.hireDate().isSame(moment(data.hireDate))){
				    self.hireDate(moment(data.hireDate));
				}
				self.lastName(data.lastName);
				self.firstName(data.firstName);
				self.fullName(data.fullName);
                if (self.afterLoadFromDto){
                    self.afterLoadFromDto();
                }
				self.isLoading(false);
				self.isDirty(false);
                self.validate();
			};

    	    // Save the object into a DTO
			self.saveToDto = function() {
				var dto: any = {};
				dto.instructorId = self.instructorId();

                if (!self.hireDate()) dto.HireDate = null;
				else dto.hireDate = self.hireDate().format('YYYY-MM-DDTHH:mm:ss');
    	        dto.lastName = self.lastName();
    	        dto.firstName = self.firstName();

				return dto;
			}

            // Methods to add to child collections


            // Save on changes
            function setupSubscriptions() {
                self.hireDate.subscribe(self.autoSave);
                self.lastName.subscribe(self.autoSave);
                self.firstName.subscribe(self.autoSave);
            }  

            // Create variables for ListEditorApiUrls
            // Create loading function for Valid Values


            // Load all child objects that are not loaded.
            self.loadChildren = function(callback) {
                var loadingCount = 0;
                if (loadingCount == 0 && $.isFunction(callback)){
                    callback();
                }
            };


            // Load all the valid values in parallel.
            self.loadValidValues = function(callback) {
                if ($.isFunction(callback)) callback();
            };

            // Enumeration Lookups.

            // This stuff needs to be done after everything else is set up.
            // Complex Type Observables

            // Make sure everything is defined before we call this.
            setupSubscriptions();

            if (newItem) {
                if ($.isNumeric(newItem)) self.load(newItem);
                else self.loadFromDto(newItem, true);
            }
        }
    }





    export namespace Instructor {

        // Classes for use in method calls to support data binding for input for arguments
    }
}