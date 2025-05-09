<!--becuase of the time limitation i have added most of ui in one component else we can separte as we need
I also used more type sefaty
I possible not add any background color or text color in template it shoud read from theam
I have used tailwind ready made component for stayling
-->
<template>
  <ag-grid-vue
    id="product-grid"
    class="m-8"
    :loading="loading"
    :rowData="rowData"
    :columnDefs="colDefs"
    style="height: 750px; width: 1250px"
  >
  </ag-grid-vue>
</template>
<script lang="ts">
import { defineComponent, ref } from 'vue'
import { AgGridVue } from 'ag-grid-vue3' // Vue Data Grid Component
import type { CoffeeBean } from '@/models/coffeebean'
import { getProducts } from '../services/data.service.ts'
import HeaderActionComponent from '@/components/HeaderActionComponent.vue'
import CustomDeleteButtonComponent from '@/components/CustomDeleteButtonComponent.vue'
import CustomEditButtonComponent from '@/components/CustomEditButtonComponent.vue'
import type { ICellEditorRendererParams, ITooltipParams } from 'ag-grid-community'
export default defineComponent({
  name: 'ProductsView',
  components: { AgGridVue },
  mounted() {
    this.loading = true
    // here we can use rxjs  which very powerfull
    getProducts()
      .then((response) => {
        this.loading = false
        this.rowData = response.data as CoffeeBean[]
      })
      .catch((error) => {
        console.error(error)
        this.loading = false
      })
  },
  data() {
    return {
      loading: true,
      rowData: ref([] as CoffeeBean[]),
      colDefs: ref([
        { field: 'index', maxWidth: 80, filter: 'agNumberColumnFilter' },
        { field: 'name', maxWidth: 150, filter: 'agTextColumnFilter' },
        {
          field: 'description',
          filter: 'agTextColumnFilter',
          tooltipValueGetter: (p: ITooltipParams<CoffeeBean>) => p.data?.description,
        },
        {
          field: 'image',
          filter: 'agTextColumnFilter',
          tooltipValueGetter: (p: ITooltipParams<CoffeeBean>) => p.data?.image,
        },
        { field: 'colour', maxWidth: 150, filter: 'agTextColumnFilter' },
        { field: 'isBOTD', maxWidth: 80, filter: 'agDateColumnFilter' },
        { field: 'country', maxWidth: 150, filter: 'agTextColumnFilter' },
        { field: 'cost', maxWidth: 80, filter: 'agTextColumnFilter' },
        {
          field: 'button',
          maxWidth: 50,
          headerName: 'Add',
          headerComponent: HeaderActionComponent,
          cellRenderer: CustomEditButtonComponent,
          cellRendererParams: (x: ICellEditorRendererParams<CoffeeBean>) => {
            const product = x.value
            return product
          },
        },
        {
          field: 'button',
          maxWidth: 50,
          headerName: '',
          cellRenderer: CustomDeleteButtonComponent,
          cellRendererParams: (x: ICellEditorRendererParams<CoffeeBean>) => {
            const product = x.value
            return product
          },
        },
      ]),
    }
  },
})
</script>
