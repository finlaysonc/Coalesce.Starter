
/// <reference path="../coalesce.dependencies.d.ts" />

// Knockout View Model for: ShortBlog
// Auto Generated by IntelliTect.Coalesce

module ViewModels {

	export class ShortBlog extends Coalesce.BaseViewModel<ShortBlog>
    {
        protected modelName = "ShortBlog";
        protected primaryKeyName = "blogId";
        protected modelDisplayName = "Short Blog";

        protected apiController = "/ShortBlog";
        protected viewController = "/ShortBlog";
        public dataSources = ListViewModels.ShortBlogDataSources;


        // The custom code to run in order to pull the initial datasource to use for the object that should be returned
        public dataSource: ListViewModels.ShortBlogDataSources = ListViewModels.ShortBlogDataSources.Default;

        public static coalesceConfig
            = new Coalesce.ViewModelConfiguration<ShortBlog>(Coalesce.GlobalConfiguration.viewModel);
        public coalesceConfig: Coalesce.ViewModelConfiguration<ShortBlog>
            = new Coalesce.ViewModelConfiguration<ShortBlog>(ShortBlog.coalesceConfig);
    
        // Observables
        public blogId: KnockoutObservable<number> = ko.observable(null);
        public url: KnockoutObservable<string> = ko.observable(null);

       
        // Create computeds for display for objects
        

                // Pops up a stock editor for this object.



        
        public originalData: KnockoutObservable<any> = ko.observable(null);
        
        // This method gets called during the constructor. This allows injecting new methods into the class that use the self variable.
        public init(myself: ShortBlog) {};

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
            
            self.errors = ko.validation.group([
                self.blogId,
                self.url,
            ]);
            self.warnings = ko.validation.group([
            ]);

            // Computed Observable for edit URL
            self.editUrl = ko.computed(function() {
                return self.coalesceConfig.baseViewUrl() + self.viewController + "/CreateEdit?id=" + self.blogId();
            });

            // Create computeds for display for objects


            // Load the ViewModel object from the DTO. 
            // Force: Will override the check against isLoading that is done to prevent recursion. False is default.
            // AllowCollectionDeletes: Set true when entire collections are loaded. True is the default. In some cases only a partial collection is returned, set to false to only add/update collections.
			self.loadFromDto = function(data: any, force: boolean = false, allowCollectionDeletes: boolean = true) {
				if (!data || (!force && self.isLoading())) return;
				self.isLoading(true);
				// Set the ID 
				self.myId = data.blogId;
				self.blogId(data.blogId);
				// Load the lists of other objects
				// Objects are loaded first so that they are available when the IDs get loaded.
				// This handles the issue with populating select lists with correct data because we now have the object.

				// The rest of the objects are loaded now.
				self.url(data.url);
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
				dto.blogId = self.blogId();

    	        dto.url = self.url();

				return dto;
			}

            // Methods to add to child collections


            // Save on changes
            function setupSubscriptions() {
                self.url.subscribe(self.autoSave);
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





    export namespace ShortBlog {

        // Classes for use in method calls to support data binding for input for arguments
    }
}