import { describe, it, expect } from 'vitest'

import { mount } from '@vue/test-utils'
import CardComponent from '../CardComponent.vue'

describe('Render', () => {
  it('CardComponent', () => {
    const wrapper = mount(CardComponent, {
      props: {
        product: {
          id: 'e0443327-da54-45b0-c611-08dd8b579524',
          index: 0,
          isBOTD: false,
          cost: '£39.26',
          image: 'https://images.unsplash.com/photo-1672306319681-7b6d7ef349cf',
          colour: 'dark roast',
          name: 'TURNABOUT',
          description:
            'Ipsum cupidatat nisi do elit veniam Lorem magna. Ullamco qui exercitation fugiat pariatur sunt dolore Lorem magna magna pariatur minim. Officia amet incididunt ad proident. Dolore est irure ex fugiat. Voluptate sunt qui ut irure commodo excepteur enim labore incididunt quis duis. Velit anim amet tempor ut labore sint deserunt.\r\n',
          country: 'Peru',
        },
      },
    })
    expect(wrapper.text()).toContain('TURNABOUT')
  })
})
