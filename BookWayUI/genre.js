const genre ={
    template: `
    <div>
        <button 
        type="button" 
        class="btn btn-primary m-2 float-end" 
        data-bs-toggle="modal" 
        data-bs-target="#modalActions"
        @click="showAddModal()">
            Add New Genre
        </button>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>
                        Genre
                    </th>
                    <th>
                        Options
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="genre in genres">
                    <td>{{genre.Name}}</td>
                    <td>
                        <button 
                        type="button" 
                        class="btn btn-light mr-1"
                        data-bs-toggle="modal" 
                        data-bs-target="#modalActions"
                        @click="showUpdateModal(genre)">
                            <i class="bi bi-pencil-square"></i>
                        </button>

                        <button 
                        type="button" 
                        class="btn btn-light mr-1"
                        data-bs-toggle="modal" 
                        data-bs-target="#modalActions"
                        @click="showDeleteModal(genre)">
                            <i class="bi bi-trash-fill"></i>
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>

        <div class="modal fade" id="modalActions" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-lg modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="modalActionsTitle">{{modalTitle}}</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="input-group mb-3">
                            <span class="input-group-text">Name</span>
                            <input type="text" class="form-control" v-model="Name">
                        </div>

                        <button 
                        type="button" 
                        v-if="Id.length < 1" 
                        class="btn btn-primary"
                        @click="addGenre()">
                            Add
                        </button>
                        <button 
                        type="button" 
                        v-if="Id.length >= 1" 
                        class="btn btn-primary"
                        @click="updateGenre()">
                            Update
                        </button>
                    </div>
                </div>
            </div>
        </div>

    </div>
    `,
    data() {
        return {
            genres: [],
            modalTitle: 'Edit Genre',
            Id: '',
            Name: '',
        }
    },
    methods: {
        refreshGenreData() {
            axios.get(`${variables.API_URL}/genres`).then(response => {
                this.genres = response.data
            })
        },
        showAddModal() {
            this.modalTitle = 'Add New Genre'
            this.Id = '';
            this.Name = '';
        },
        showUpdateModal(genre) {
            this.modalTitle = 'Edit Genre'
            this.Id = genre.Id;
            this.Name = genre.Name;
        },
        showDeleteModal(genre) {
            this.modalTitle = 'Delete Genre'
            this.Id = genre.Id;
            this.Name = genre.Name;
        }
    },
    mounted: function() {
        this.refreshGenreData();
    }
}