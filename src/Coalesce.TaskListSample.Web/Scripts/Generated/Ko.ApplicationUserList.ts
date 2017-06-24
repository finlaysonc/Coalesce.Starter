
/// <reference path="../coalesce.dependencies.d.ts" />

// Knockout List View Model for: ApplicationUser
// Auto Generated by IntelliTect.Coalesce

var baseUrl = baseUrl || '';

module ListViewModels {

    // Add an enum for all methods that are static and IQueryable
    export enum ApplicationUserDataSources {
            Default,
        }
    export class ApplicationUserList extends Coalesce.BaseListViewModel<ApplicationUserList, ViewModels.ApplicationUser> {
        protected modelName = "ApplicationUser";

        protected apiController = "/ApplicationUser";

        public modelKeyName = "applicationUserId";
        public dataSources = ApplicationUserDataSources;
        public itemClass = ViewModels.ApplicationUser;

        public query: {
            where?: string;
            applicationUserId?:number;
            name?:String;
        } = null;

        // The custom code to run in order to pull the initial datasource to use for the collection that should be returned
        public listDataSource: ApplicationUserDataSources = ApplicationUserDataSources.Default;

        public static coalesceConfig = new Coalesce.ListViewModelConfiguration<ApplicationUserList, ViewModels.ApplicationUser>(Coalesce.GlobalConfiguration.listViewModel);
        public coalesceConfig = new Coalesce.ListViewModelConfiguration<ApplicationUserList, ViewModels.ApplicationUser>(ApplicationUserList.coalesceConfig);

        // Valid values
    
        protected createItem = (newItem?: any, parent?: any) => new ViewModels.ApplicationUser(newItem, parent);

        constructor() {
            super();
        }
    }

    export namespace ApplicationUserList {
        // Classes for use in method calls to support data binding for input for arguments
    }
}