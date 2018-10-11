<template>
    <b-modal title="Add Spell" id="spellModal" size="lg">
        <b-form inline>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label class="d-block" for="nameInput">
                        <strong>Name</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input class="mb-2 mr-sm-2 mb-sm-0" id="nameInput" placeholder="ex. Magic Missile" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="classInput">
                        <strong>Classes</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="classInput" placeholder="ex. Wizard, Sorcerer, Druid" />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-12">
                    <label class="d-block" for="descInput">
                        <strong>Description</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0 max-width-override">
                        <textarea rows="3" max-rows="8" class="form-control" id="descriptionInput" style="resize: none; overflow-x: hidden; overflow-y: scroll;" placeholder="ex. <p>You create three magic darts. Each dart hits a creature you can see. A dart deals 1d4+1 force damage. The darts all strike simultaneously and you can direct them to hit one creature or several.</p>"  />
                    </b-input-group>
                    <br>
                </div>
                <div class="col-md-6">
                    <label class="d-block" for="componentsInput">
                        <strong>Components</strong>
                    </label>
                    <b-input-group left="@" class="mb-2 mr-sm-2 mb-sm-0">
                        <b-input id="componentsInput" placeholder="ex. V, S, M" />
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

.max-width-override {
    max-width: 100%;
}
</style>