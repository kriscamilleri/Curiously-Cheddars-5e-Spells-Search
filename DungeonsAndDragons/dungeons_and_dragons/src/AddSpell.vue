<template>
    <b-modal title="Add Spell" id="spellModal" size="lg" class="modal-full" ok-variant="success" ok-title="Save">
        <b-form action="/api/values/addspell" inline>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label class="d-block" for="nameInput">
                        <strong>Name</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="nameInput" name="nameInput" placeholder="ex. Magic Missile" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="levelsInput">
                        <strong>Level</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="levelsInput" name="levelsInput" placeholder="ex. 9" type="number" min="0" max="9" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-12">
                    <label class="d-block" for="descInput">
                        <strong>Description</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0 max-width-override">
                        <textarea rows="3" name="descInput" max-rows="8" class="form-control" id="descriptionInput" placeholder="ex. <p>You create three magic darts. Each dart hits a creature you can see. A dart deals 1d4+1 force damage. The darts all strike simultaneously and you can direct them to hit one creature or several.</p>" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-12">
                    <label class="d-block" for="higherLevelsInput">
                        <strong>Higher Levels</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0  max-width-override">
                        <textarea rows="3" name="higherLevelsInput" max-rows="8" class="form-control" id="higherLevelsInput" placeholder="ex. <p>The spell creates one more dart for each slot above 1st.</p>" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="classInput">
                        <strong>Classes</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="classInput" name="classInput" placeholder="ex. Wizard, Sorcerer, Druid" />
                    </b-input-group>
                    <br>
                </div>
               
                <div class="col-md-6">
                    <label class="d-block" for="rangeInput">
                        <strong>Range</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="rangeInput" name="rangeInput" placeholder="ex. 50ft" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="durationInput">
                        <strong>Duration</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="durationInput" name="durationInput" placeholder="ex. 1 minute" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="castingTimeInput">
                        <strong>Casting Time</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="castingTimeInput" name="castingTimeInput" placeholder="ex. 1 minute" />
                    </b-input-group>
                    <br>
                </div>
                 <div class="col-md-6">
                    <label class="d-block" for="schoolInput">
                        <strong>School</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="schoolInput" name="schoolInput" placeholder="ex Necromancy" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="somaticInput">
                        <strong>Somatic</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-form-select class="mb-2 mr-sm-2 mb-sm-0" :value="false" :options="{ true: 'True', false: 'False' }" id="somaticInput" name="somaticInput" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="verbalInput">
                        <strong>Verbal</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-form-select class="mb-2 mr-sm-2 mb-sm-0" :value="false" :options="{ true: 'True', false: 'False' }" id="verbalInput" name="verbalInput" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="ritualInput">
                        <strong>Ritual</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-form-select class="mb-2 mr-sm-2 mb-sm-0" :value="false" :options="{ true: 'True', false: 'False' }" id="ritualInput" name="ritualInput" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="concentrationInput">
                        <strong>Concentration</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-form-select class="mb-2 mr-sm-2 mb-sm-0" :value="false" :options="{ true: 'True', false: 'False' }" id="concentrationInput" name="concentrationInput" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="materialCostInput">
                        <strong>Material Cost</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-form-select class="mb-2 mr-sm-2 mb-sm-0" :value="false" :options="{ true: 'True', false: 'False' }" id="materialCostInput" name="materialCostInput" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="materialInput">
                        <strong>Material</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="materialInput" name="materialInput" placeholder="ex. A red dragon's scale." />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="levelsInput">
                        <strong>Page</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="pageInput" name="pageInput" placeholder="ex. 145" type="number" min="0" max="1000" />
                    </b-input-group>
                    <br>
                </div>
            </div>
        </b-form>
    </b-modal>
</template>

<script>
export default {
    name: "AddSpell"
};
</script>
<style>
.input-group>.custom-file,
.input-group>.custom-select,
.input-group>.form-control {
    width: 100%;
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
}

.modal .input-group .input {
    width: 100%;
    max-width: 100%;
}

.modal .input-group {
    width: 100%;
    max-width: 100%;
}

.max-width-override {
    max-width: 100%;
}

.modal {
    padding-right: 0 !important;
}

.modal-full {
    min-width: 100%;
    margin: 0 !important;
}

.modal-full .modal-dialog {
    min-width: 100%;
    margin: 0;
}

.modal-full .modal-content {
    min-height: 100vh;
    padding: 4rem;
}

.modal .close {
    margin-top: -4rem;
    margin-right: -4rem;
    font-size: 2rem;
}

.modal .custom-select{
    background: none;
}
</style>