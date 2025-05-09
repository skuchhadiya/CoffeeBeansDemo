<!--Note:  becuase of the time limitation i have added most of ui in one component else we can separte as we need, I have try in many area here we can separte Nav, Filter, Search Input, Sort, Header in diffrent component in listen verious event through pinia
If I have time I possible used more type sefaty as this is demo so not sepnt much time on it. Have did in many places So you know How we can add type safe
I possible not add any background color or text color in template it shoud read from theam
I have used tailwind ready made component for stayling this something i have learn on this project i naver used tailwind before
This responsive design you can check in mobile as well it render nicely
-->
<template>
  <TransitionRoot as="template" :show="mobileFiltersOpen">
    <Dialog class="relative z-40 lg:hidden" @close="mobileFiltersOpen = false">
      <TransitionChild
        as="template"
        enter="transition-opacity ease-linear duration-300"
        enter-from="opacity-0"
        enter-to="opacity-100"
        leave="transition-opacity ease-linear duration-300"
        leave-from="opacity-100"
        leave-to="opacity-0"
      >
        <div class="fixed inset-0 bg-black/25" />
      </TransitionChild>

      <div class="fixed inset-0 z-40 flex">
        <TransitionChild
          as="template"
          enter="transition ease-in-out duration-300 transform"
          enter-from="translate-x-full"
          enter-to="translate-x-0"
          leave="transition ease-in-out duration-300 transform"
          leave-from="translate-x-0"
          leave-to="translate-x-full"
        >
          <DialogPanel
            class="relative ml-auto flex size-full max-w-xs flex-col overflow-y-auto bg-white py-4 pb-12 shadow-xl"
          >
            <div class="flex items-center justify-between px-4">
              <h2 class="text-lg font-medium text-gray-900">Filters</h2>
              <button
                type="button"
                class="-mr-2 flex size-10 items-center justify-center rounded-md bg-white p-2 text-gray-400"
                @click="mobileFiltersOpen = false"
              >
                <span class="sr-only">Close menu</span>
                <XMarkIcon class="size-6" aria-hidden="true" />
              </button>
            </div>

            <!-- Filters -->
            <form class="mt-4 border-t border-gray-200">
              <div
                class="p-4 ml-4 mr-4 flex px-4 py-3 rounded-md border-2 border-blue-500 overflow-hidden max-w-md mx-auto"
              >
                <svg
                  xmlns="http://www.w3.org/2000/svg"
                  viewBox="0 0 192.904 192.904"
                  width="16px"
                  class="fill-gray-600 mr-3 rotate-90"
                >
                  <path
                    d="m190.707 180.101-47.078-47.077c11.702-14.072 18.752-32.142 18.752-51.831C162.381 36.423 125.959 0 81.191 0 36.422 0 0 36.423 0 81.193c0 44.767 36.422 81.187 81.191 81.187 19.688 0 37.759-7.049 51.831-18.751l47.079 47.078a7.474 7.474 0 0 0 5.303 2.197 7.498 7.498 0 0 0 5.303-12.803zM15 81.193C15 44.694 44.693 15 81.191 15c36.497 0 66.189 29.694 66.189 66.193 0 36.496-29.692 66.187-66.189 66.187C44.693 147.38 15 117.689 15 81.193z"
                  ></path>
                </svg>
                <input
                  type="text"
                  placeholder="Search Something..."
                  v-model="input"
                  class="w-full outline-none bg-transparent text-gray-600 text-sm"
                />
              </div>

              <Disclosure
                as="div"
                v-for="section in filters"
                :key="section.id"
                class="border-t border-gray-200 px-4 py-6"
                v-slot="{ open }"
              >
                <h3 class="-mx-2 -my-3 flow-root">
                  <DisclosureButton
                    class="flex w-full items-center justify-between bg-white px-2 py-3 text-gray-400 hover:text-gray-500"
                  >
                    <span class="font-medium text-gray-900">{{ section.name }}</span>
                    <span class="ml-6 flex items-center">
                      <PlusIcon v-if="!open" class="size-5" aria-hidden="true" />
                      <MinusIcon v-else class="size-5" aria-hidden="true" />
                    </span>
                  </DisclosureButton>
                </h3>
                <DisclosurePanel class="pt-6">
                  <div class="space-y-6">
                    <div
                      v-for="(option, optionIdx) in section.options"
                      :key="option.value"
                      class="flex gap-3"
                    >
                      <div class="flex h-5 shrink-0 items-center">
                        <div class="group grid size-4 grid-cols-1">
                          <input
                            :id="`filter-mobile-${section.id}-${optionIdx}`"
                            :name="`${section.id}[]`"
                            v-model="option.checked"
                            @click="filterChnage"
                            type="checkbox"
                            class="col-start-1 row-start-1 appearance-none rounded-sm border border-gray-300 bg-white checked:border-indigo-600 checked:bg-indigo-600 indeterminate:border-indigo-600 indeterminate:bg-indigo-600 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600 disabled:border-gray-300 disabled:bg-gray-100 disabled:checked:bg-gray-100 forced-colors:appearance-auto"
                          />
                          <svg
                            class="pointer-events-none col-start-1 row-start-1 size-3.5 self-center justify-self-center stroke-white group-has-disabled:stroke-gray-950/25"
                            viewBox="0 0 14 14"
                            fill="none"
                          >
                            <path
                              class="opacity-0 group-has-checked:opacity-100"
                              d="M3 8L6 11L11 3.5"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                            <path
                              class="opacity-0 group-has-indeterminate:opacity-100"
                              d="M3 7H11"
                              stroke-width="2"
                              stroke-linecap="round"
                              stroke-linejoin="round"
                            />
                          </svg>
                        </div>
                      </div>
                      <label
                        :for="`filter-mobile-${section.id}-${optionIdx}`"
                        class="min-w-0 flex-1 text-gray-500"
                        >{{ option.label }}</label
                      >
                    </div>
                  </div>
                </DisclosurePanel>
              </Disclosure>
            </form>
          </DialogPanel>
        </TransitionChild>
      </div>
    </Dialog>
  </TransitionRoot>
  <main class="mx-auto max-w-7xl px-4 sm:px-6 lg:px-8">
    <div class="flex items-baseline justify-between border-b border-gray-200 pt-4 pb-6">
      <h1 class="text-4xl font-bold tracking-tight text-gray-900">New Arrivals</h1>

      <div class="flex items-center">
        <Menu as="div" class="relative inline-block text-left">
          <div>
            <MenuButton
              class="group inline-flex justify-center text-sm font-medium text-gray-700 hover:text-gray-900"
            >
              Sort
              <ChevronDownIcon
                class="-mr-1 ml-1 size-5 shrink-0 text-gray-400 group-hover:text-gray-500"
                aria-hidden="true"
              />
            </MenuButton>
          </div>
          <transition
            enter-active-class="transition ease-out duration-100"
            enter-from-class="transform opacity-0 scale-95"
            enter-to-class="transform opacity-100 scale-100"
            leave-active-class="transition ease-in duration-75"
            leave-from-class="transform opacity-100 scale-100"
            leave-to-class="transform opacity-0 scale-95"
          >
            <MenuItems
              class="absolute right-0 z-10 mt-2 w-40 origin-top-right rounded-md bg-white shadow-2xl ring-1 ring-black/5 focus:outline-hidden"
            >
              <div class="py-1">
                <MenuItem v-for="option in sortOptions" :key="option.name" v-slot="{ active }">
                  <a
                    :href="option.href"
                    :class="[
                      option.current ? 'font-medium text-gray-900' : 'text-gray-500',
                      active ? 'bg-gray-100 outline-hidden' : '',
                      'block px-4 py-2 text-sm',
                    ]"
                    >{{ option.name }}</a
                  >
                </MenuItem>
              </div>
            </MenuItems>
          </transition>
        </Menu>
        <button
          type="button"
          class="-m-2 ml-4 p-2 text-gray-400 hover:text-gray-500 sm:ml-6 lg:hidden"
          @click="mobileFiltersOpen = true"
        >
          <span class="sr-only">Filters</span>
          <FunnelIcon class="size-5" aria-hidden="true" />
        </button>
      </div>
    </div>
    <section aria-labelledby="products-heading" class="pt-6 pb-24">
      <h2 id="products-heading" class="sr-only">Products</h2>
      <div class="grid grid-cols-1 gap-x-8 gap-y-10 lg:grid-cols-4">
        <!-- Filters -->
        <form class="hidden lg:block">
          <!-- Serach Input -->
          <div
            class="flex px-4 py-3 rounded-md border-2 border-blue-500 overflow-hidden max-w-md mx-auto"
          >
            <svg
              xmlns="http://www.w3.org/2000/svg"
              viewBox="0 0 192.904 192.904"
              width="16px"
              class="fill-gray-600 mr-3 rotate-90"
            >
              <path
                d="m190.707 180.101-47.078-47.077c11.702-14.072 18.752-32.142 18.752-51.831C162.381 36.423 125.959 0 81.191 0 36.422 0 0 36.423 0 81.193c0 44.767 36.422 81.187 81.191 81.187 19.688 0 37.759-7.049 51.831-18.751l47.079 47.078a7.474 7.474 0 0 0 5.303 2.197 7.498 7.498 0 0 0 5.303-12.803zM15 81.193C15 44.694 44.693 15 81.191 15c36.497 0 66.189 29.694 66.189 66.193 0 36.496-29.692 66.187-66.189 66.187C44.693 147.38 15 117.689 15 81.193z"
              ></path>
            </svg>
            <input
              type="text"
              placeholder="Search Something..."
              v-model="input"
              class="w-full outline-none bg-transparent text-gray-600 text-sm"
            />
          </div>
          <Disclosure
            as="div"
            v-for="section in filters"
            :key="section.id"
            class="border-b border-gray-200 py-6"
            v-slot="{ open }"
          >
            <h3 class="-my-3 flow-root">
              <DisclosureButton
                class="flex w-full items-center justify-between bg-white py-3 text-sm text-gray-400 hover:text-gray-500"
              >
                <span class="font-medium text-gray-900">{{ section.name }}</span>
                <span class="ml-6 flex items-center">
                  <PlusIcon v-if="!open" class="size-5" aria-hidden="true" />
                  <MinusIcon v-else class="size-5" aria-hidden="true" />
                </span>
              </DisclosureButton>
            </h3>
            <DisclosurePanel class="pt-6">
              <div class="space-y-4">
                <div
                  v-for="(option, optionIdx) in section.options"
                  :key="option.value"
                  class="flex gap-3"
                >
                  <div class="flex h-5 shrink-0 items-center">
                    <div class="group grid size-4 grid-cols-1">
                      <input
                        :id="`filter-${section.id}-${optionIdx}`"
                        :name="`${section.id}[]`"
                        v-model="option.checked"
                        @click="filterChnage"
                        type="checkbox"
                        class="col-start-1 row-start-1 appearance-none rounded-sm border border-gray-300 bg-white checked:border-indigo-600 checked:bg-indigo-600 indeterminate:border-indigo-600 indeterminate:bg-indigo-600 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600 disabled:border-gray-300 disabled:bg-gray-100 disabled:checked:bg-gray-100 forced-colors:appearance-auto"
                      />
                      <svg
                        class="pointer-events-none col-start-1 row-start-1 size-3.5 self-center justify-self-center stroke-white group-has-disabled:stroke-gray-950/25"
                        viewBox="0 0 14 14"
                        fill="none"
                      >
                        <path
                          class="opacity-0 group-has-checked:opacity-100"
                          d="M3 8L6 11L11 3.5"
                          stroke-width="2"
                          stroke-linecap="round"
                          stroke-linejoin="round"
                        />
                        <path
                          class="opacity-0 group-has-indeterminate:opacity-100"
                          d="M3 7H11"
                          stroke-width="2"
                          stroke-linecap="round"
                          stroke-linejoin="round"
                        />
                      </svg>
                    </div>
                  </div>
                  <label :for="`filter-${section.id}-${optionIdx}`" class="text-sm text-gray-600">{{
                    option.label
                  }}</label>
                </div>
              </div>
            </DisclosurePanel>
          </Disclosure>
        </form>

        <!-- Product grid -->
        <div class="lg:col-span-3">
          <LoadingComponent
            v-if="loading"
            :loading="loading"
            class="text-center"
          ></LoadingComponent>
          <div v-else class="p-8 grid grid-flow-row-dense grid-cols-3 grid-rows gap-4">
            <div
              v-for="product in getCoffeBeansProducts ?? []"
              :key="product.id"
              class="max-w-xs rounded overflow-hidden shadow-lg flex flex-col justify-between"
            >
              <CardComponent :product="product" />
            </div>
          </div>
        </div>
      </div>
    </section>
  </main>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import CardComponent from '@/components/CardComponent.vue' // @ is an alias to /src
import {
  Disclosure,
  DisclosureButton,
  DisclosurePanel,
  Menu,
  MenuButton,
  MenuItem,
  MenuItems,
  Dialog,
  DialogPanel,
  TransitionChild,
  TransitionRoot,
} from '@headlessui/vue'
import { XMarkIcon } from '@heroicons/vue/24/outline'
import { ChevronDownIcon, FunnelIcon, MinusIcon, PlusIcon } from '@heroicons/vue/20/solid'
import { ref } from 'vue'
import { getProducts } from '../services/data.service.ts'
import type { CoffeeBean } from '@/models/coffeebean.ts'
import { productStore } from '@/stores/index.ts'
import LoadingComponent from '@/components/LoadingComponent.vue'

export default defineComponent({
  name: 'HomeView',
  setup() {
    const productStr = productStore()
    return { productStr }
  },
  methods: {
    filterChnage() {
      setTimeout(() => {
        //Filter logic in HomeView
        const filterModel = this.getFilterModel()
        const newProducts = this.copyProducts.filter((x) => {
          const result =
            ((filterModel.isTextSearchActive === true &&
              x.name.startsWith(filterModel.searchText)) ||
              filterModel.isTextSearchActive == false) &&
            (x.isBOTD === filterModel.isBOTD || x.isBOTD === undefined) &&
            (filterModel.colour?.includes(x.colour) || filterModel.colour?.length === 0) &&
            (filterModel.country?.includes(x.country) || filterModel.country?.length === 0)
          return result
        })
        this.productStr.setProducts(newProducts as CoffeeBean[])
      }, 5)
    },
    //Creating filter model
    getFilterModel() {
      const filterModel = {
        isTextSearchActive: this.searchTerm.length > 0,
        searchText: this.searchTerm,
        isBOTD: this.filters
          .find((x) => x.id === 'isBOTD')
          ?.options.find((x) => x.value === 'isBOTD')?.checked,
        colour: this.filters
          .find((x) => x.id === 'colour')
          ?.options.filter((x) => x.checked === true)
          .map((x) => x.value),
        country: this.filters
          .find((x) => x.id === 'country')
          ?.options.filter((x) => x.checked === true)
          .map((x) => x.value),
      }
      return filterModel
    },
  },
  computed: {
    input: {
      get() {
        return this.searchTerm
      },
      set(val: string) {
        if (this.timeout) clearTimeout(this.timeout)
        this.timeout = setTimeout(() => {
          this.searchTerm = val
          this.filterChnage()
        }, 800)
      },
    },
    getCoffeBeansProducts() {
      return this.productStr.getProducts
    },
  },
  mounted() {
    // here we can use rxjs which very powerfull
    // for simplicity i just use promise
    getProducts()
      .then((response) => {
        this.loading = false
        this.copyProducts = response.data as CoffeeBean[]
        this.productStr.setProducts(response.data)
      })
      .catch((error) => {
        console.error(error)
        this.loading = false
        this.productStr.setProducts([] as CoffeeBean[])
      })
  },
  data() {
    return {
      loading: true,
      timeout: 300,
      copyProducts: [] as CoffeeBean[],
      //this is place holder not working I have just leave for look and fill of the home page
      sortOptions: [
        { name: 'Name', href: '#', current: true },
        { name: 'BOTD', href: '#', current: false },
        // { name: 'Price: Low to High', href: '#', current: false },
        // { name: 'Price: High to Low', href: '#', current: false },
      ],
      //this is place holder not working I have just leave for look and fill of the home page
      subCategories: [],
      searchTerm: '',
      filters: [
        {
          id: 'isBOTD',
          name: 'BOTD',
          options: [{ value: 'isBOTD', label: 'BOTD', checked: false }],
        },
        {
          id: 'colour',
          name: 'Colour',
          options: [
            { value: 'dark roast', label: 'Dark roast', checked: false },
            { value: 'golden', label: 'Golden', checked: false },
            { value: 'green', label: 'Green', checked: false },
            { value: 'light roast', label: 'Light roast', checked: false },
            { value: 'medium roast', label: 'Medium roast', checked: false },
          ],
        },
        {
          id: 'country',
          name: 'Country',
          options: [
            { value: 'Peru', label: 'Peru', checked: false },
            { value: 'Vietnam', label: 'Vietnam', checked: false },
            { value: 'Colombia', label: 'Colombia', checked: false },
            { value: 'Brazil', label: 'Brazil', checked: false },
            { value: 'Honduras', label: 'Honduras', checked: false },
          ],
        },
      ],
      mobileFiltersOpen: ref(true),
    }
  },
  components: {
    CardComponent,
    // eslint-disable-next-line vue/no-reserved-component-names
    Dialog,
    DialogPanel,
    TransitionChild,
    TransitionRoot,
    Disclosure,
    DisclosureButton,
    DisclosurePanel,
    // eslint-disable-next-line vue/no-reserved-component-names
    Menu,
    MenuButton,
    MenuItem,
    MenuItems,
    XMarkIcon,
    ChevronDownIcon,
    FunnelIcon,
    MinusIcon,
    PlusIcon,
    LoadingComponent,
  },
})
</script>
