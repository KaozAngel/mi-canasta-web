<template>
  <div class="home-container">
    <div class="field-container margin">
      <label class="label-shared-component grupo-familiar-label">Grupo Familiar</label>
      <input class="input-shared-component" type="text" v-model="grupoFamiliar" />
    </div>

    <div class="home-container__list-button">
      <ButtonShared
        :loading="loadingCreaFamiliarButton"
        :disable="grupoFamiliar.length < 1 /*|| solicitudActiva == true*/"
        :text="'Crear'"
        :type="'small'"
        :bgColor="'red'"
        @Event="crearGrupo"
      ></ButtonShared>

      <ButtonShared
        :disable="grupoFamiliar.length < 1 /*|| solicitudActiva == true*/"
        :text="'Unirse'"
        :type="'small'"
        :bgColor="'yellow'"
        @Event="unirseGrupo"
      ></ButtonShared>
    </div>

    <ErrorModalShared
      v-if="errorFlagModal"
      :title="'Lo sentimos'"
      :description="messageError"
      @Event="cerrarModal"
    ></ErrorModalShared>

    <ErrorModalShared
      class="modal-familia-no-existe"
      v-if="errorFlagModalUnirse"
      :title="'Lo sentimos'"
      :description="messageError"
      @Event="cerrarModalUnirse"
    ></ErrorModalShared>
  </div>
</template>

<script>
import FamiliaService from "../../core/services/familia.service";
import SolicitudService from "../../core/services/solicitud.service";
import ButtonShared from "../../shared/button/button.component.vue";
import ErrorModalShared from "../../shared/modal/error-modal.component.vue";
import AuthService from "../../core/services/auth.service";
export default {
  name: "HomePage",
  components: { ButtonShared, ErrorModalShared },
  data: function() {
    return {
      solicitudActiva: false,
      grupoFamiliar: "",
      loadingCreaFamiliarButton: false,
      errorFlagModal: false,
      errorFlagModalUnirse: false,
      messageError: ""
    };
  },
  created() {
    this.tieneSolicitudes();
  },

  methods: {
    async crearGrupo() {
      this.$data.loadingCreaFamiliarButton = true;
      try {
        const res = await FamiliaService.crearFamilia({
          dni: localStorage.getItem("dni"),
          familiaNombre: this.$data.grupoFamiliar
        });

        this.$data.loadingCreaFamiliarButton = false;
        let data = AuthService.getUsuarioAutenticacion();
        data.usuario.familia = {};
        data.usuario.familia.familiaId = res.data.id;
        data.usuario.familia.nombre = res.data.familiaNombre;
        AuthService.saveUsuarioAutenticacion(data);
        this.$router.push("/family/family/" + data.usuario.familia.familiaId);
      } catch (error) {
        console.log(error);
        this.messageError = `El grupo familiar '${this.$data.grupoFamiliar}' ya existe`;
        this.$data.loadingCreaFamiliarButton = false;
        this.$data.errorFlagModal = true;
      }
    },
    async unirseGrupo() {
      console.log("unirse grupo");
      try {
        const res = await SolicitudService.crearSolicitud({
          familiaNombre: this.$data.grupoFamiliar,
          //dni: "77777777"
          dni: localStorage.getItem("dni")
        });
        console.log(res);
        this.$data.errorFlagModalUnirse = true;
        this.$data.errorFlagModal = true;
        this.$router.push("/start/requests-sent");
      } catch (error) {
        console.log(error);
        this.messageError = `El grupo familiar '${this.$data.grupoFamiliar}' no existe o no está permitido el envío de solicitud en este momento`;
        this.$data.errorFlagModalUnirse = true;
      }
    },

    async tieneSolicitudes() {
      try {
        const res = await SolicitudService.obtenerSolicitudes(
          localStorage.getItem("dni")
        );
        this.$data.solicitudActiva = true;
        console.log(res);
      } catch (error) {
        this.$data.solicitudActiva = false;
      }
    },

    cerrarModal() {
      this.$data.errorFlagModal = false;
    },
    cerrarModalUnirse() {
      this.$data.errorFlagModalUnirse = false;
    }
  }
};
</script>

<style>
.home-container .field-container {
  margin: 128px 0 160px 0;
  display: flex;
  justify-content: center;
  align-items: center;
  flex-direction: column;
}
.home-container .field-container input {
  text-align: center;
}

.home-container .grupo-familiar-label {
  text-align: center;
}
.home-container__list-button {
  width: 80%;
  margin: 0 auto;
  display: flex;
  justify-content: space-around;
  align-items: center;
}
</style>
