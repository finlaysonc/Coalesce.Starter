/// <reference path="coalesce.dependencies.d.ts" />
module TaskListSimple {

    export class InstructorHomeModel {

        instructors = new ListViewModels.InstructorList();


        constructor() {
            //this.ueberJobs.listDataSource = this.ueberJobs.dataSources.UeberJobForDetails
            this.instructors.pageSize(10);
            this.instructors.load(() => {

            });
        }
    }

    $(function() {
        const model = new InstructorHomeModel();
        ko.applyBindings(model);
    });
}