
/// <reference path="../coalesce.dependencies.d.ts" />

// Knockout List View Model for: Course
// Auto Generated by IntelliTect.Coalesce

var baseUrl = baseUrl || '';

module ListViewModels {

    // Add an enum for all methods that are static and IQueryable
    export enum CourseDataSources {
            Default,
        }
    export class CourseList extends Coalesce.BaseListViewModel<CourseList, ViewModels.Course> {
        protected modelName = "Course";

        protected apiController = "/Course";

        public modelKeyName = "courseId";
        public dataSources = CourseDataSources;
        public itemClass = ViewModels.Course;

        public query: {
            where?: string;
            courseId?:number;
            title?:String;
            credits?:number;
        } = null;

        // The custom code to run in order to pull the initial datasource to use for the collection that should be returned
        public listDataSource: CourseDataSources = CourseDataSources.Default;

        public static coalesceConfig = new Coalesce.ListViewModelConfiguration<CourseList, ViewModels.Course>(Coalesce.GlobalConfiguration.listViewModel);
        public coalesceConfig = new Coalesce.ListViewModelConfiguration<CourseList, ViewModels.Course>(CourseList.coalesceConfig);

        // Valid values
    
        protected createItem = (newItem?: any, parent?: any) => new ViewModels.Course(newItem, parent);

        constructor() {
            super();
        }
    }

    export namespace CourseList {
        // Classes for use in method calls to support data binding for input for arguments
    }
}