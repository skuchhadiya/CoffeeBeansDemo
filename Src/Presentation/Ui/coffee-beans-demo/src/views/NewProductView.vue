<template>
  <ProductDetailEditorComponent
    title="Create new Coffeebean product"
    buttonText="Create"
    :editableProduct="newProduct"
    :loading="loading"
    :handleSubmit="handleSubmit"
  ></ProductDetailEditorComponent>
</template>
<script lang="ts">
import { addNewCoffeeBeanProduct } from '../services/data.service.ts'
import type { EditableCoffeeBeanProduct } from '@/models/editableCoffeeBeanProduct.ts'
import ProductDetailEditorComponent from '@/components/ProductDetailEditorComponent.vue'
import router from '@/router/index.ts'
import { defineComponent } from 'vue'
export default defineComponent({
  name: 'NewProductView',
  components: {
    ProductDetailEditorComponent,
  },
  methods: {
    selectColour(value: string): void {
      this.newProduct.colour = value
    },
    selectCountry(value: string): void {
      this.newProduct.country = value
    },
    async handleSubmit(product: EditableCoffeeBeanProduct) {
      // assuming that we have sufficient security in palce to handle this request
      this.loading = true
      addNewCoffeeBeanProduct(product)
        .then(() => {
          this.loading = false
          router.go(-1)
          this.newProduct = {
            name: '',
            description: '',
            country: '',
            colour: '',
            image: '',
            cost: '',
            isBOTD: false,
          } as EditableCoffeeBeanProduct
        })
        .catch((error) => {
          console.error(error)
          this.loading = false
        })
    },
  },
  data() {
    return {
      loading: false,
      newProduct: {
        name: '',
        description: '',
        country: '',
        colour: '',
        image: '',
        cost: '',
        isBOTD: false,
      } as EditableCoffeeBeanProduct,
    }
  },
})
</script>
