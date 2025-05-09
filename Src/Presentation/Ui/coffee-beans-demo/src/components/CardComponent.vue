<template>
  <div v-if="product">
    <img
      class="w-full"
      :src="product.image"
      style="max-height: 300px"
      alt="Product Image not found"
    />
    <div>
      <div class="px-6 py-4">
        <div class="flex flex-row font-bold text-xl mb-2">
          {{ product.name }}
          &nbsp;
          <span v-if="product.isBOTD">
            <img
              class="rounded-full"
              style="height: 30px; width: 30px; cursor: pointer"
              src="../assets/icons/star.svg"
              title="Bean of the Day"
              alt="Bean of the Day"
              @click="openModalBOTDDailig"
          /></span>
          <DialogComponent
            v-bind:isOpen="isOpenBOTD"
            titleText="Bean of the Day"
            :dialogText="botdMsg"
            okButtonText="Ok"
            :close="closeModelBOTDDailig"
          ></DialogComponent>
        </div>

        <p class="text-gray-700 text-base">
          {{ product.description }}
        </p>
        <div class="flex flex-col">
          <div
            class="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2"
          >
            Colour: {{ product.colour }}
          </div>
          <div
            class="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2"
          >
            Country: {{ product.country }}
          </div>
        </div>
      </div>
    </div>
  </div>
  <footer v-if="product" class="m-2 h-15 bg-blue-650">
    <div class="grid h-12 grid-cols-2 items-center content-stretch gap-4 ...">
      <div>
        <span
          class="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700"
          >Cost: {{ product.cost }}</span
        >
      </div>
      <div>
        <button
          type="button"
          @click="openModal"
          class="text-white bg-gradient-to-r from-green-400 via-green-500 to-green-600 hover:bg-gradient-to-br focus:ring-4 focus:outline-none focus:ring-green-300 dark:focus:ring-green-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center me-2 mb-2"
        >
          Buy Now
        </button>
      </div>
    </div>
  </footer>
  <PurchaseComponent
    v-bind:isOpen="isOpen"
    :product="product"
    :close="handleSubmit"
  ></PurchaseComponent>
</template>
<script lang="ts">
import { defineComponent } from 'vue'
import type { PropType } from 'vue'
import type { CoffeeBean } from '@/models/coffeebean'
import DialogComponent from '@/components/DialogComponent.vue'
import PurchaseComponent from '@/components/PurchaseComponent.vue'
import { getBOTDProductDetail } from '@/services/data.service'
import type { PurchaseProduct } from '@/models/purchaseProduct'
export default defineComponent({
  name: 'CardComponent',
  components: {
    DialogComponent,
    PurchaseComponent,
  },
  data() {
    return {
      isOpen: false,
      isOpenBOTD: false,
      loading: false,
      botdMsg: '',
    }
  },
  props: {
    product: Object as PropType<CoffeeBean>,
  },
  methods: {
    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    closeModelBOTDDailig(_value: boolean) {
      this.isOpenBOTD = false
    },
    openModalBOTDDailig() {
      getBOTDProductDetail()
        .then((response) => {
          this.botdMsg = response.data
          this.isOpenBOTD = true
          this.loading = false
        })
        .catch((error) => {
          this.loading = false
          console.error(error)
        })
    },
    openModal() {
      this.isOpen = true
    },
    handleSubmit(purchaseFormValue?: PurchaseProduct) {
      this.isOpen = false
      console.log(purchaseFormValue)
    },
  },
})
</script>
