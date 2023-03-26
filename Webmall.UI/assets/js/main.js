'use strict';

document.addEventListener('DOMContentLoaded', () => {
  /* ------------ Tabs ------------ */
  document.querySelectorAll('.js-tabs').forEach((tabsContainer) => {
    tabsContainer.querySelectorAll('.js-tabs-trigger').forEach((trigger, i) => {
      trigger.addEventListener('click', (e) => {
        const target = e.target.closest('.js-tabs-trigger');

        e.preventDefault();

        if (target.classList.contains('is-active')) return;

        const hash = target.getAttribute('href');

        if (hash != '#') {
          window.location.hash = hash;
        }

        const root = target.closest('.js-tabs');

        switchTabClasses(root, i);
      });
    });
  });

  function switchTabClasses(root, i) {
    root.querySelectorAll('.js-tabs-trigger').forEach(trigger => trigger.classList.remove('is-active'));
    root.querySelectorAll('.js-tabs-pane').forEach(pane => pane.classList.remove('is-active') );

    root.querySelector(`.tabs__item:nth-child(${i + 1}) .js-tabs-trigger`).classList.add('is-active');
    root.querySelector(`.js-tabs-pane:nth-child(${i + 1})`).classList.add('is-active');
  }

  /* Tabs Hash */
  const currentHash = window.location.hash;
  const hashTab = document.querySelector('.js-tabs-trigger[href="' + currentHash + '"]');

  if (hashTab) {
    const ev = new Event('click');
    hashTab.dispatchEvent(ev);
  }
  /* /Tabs Hash */

  /* Tabs Accordeon */
  document.addEventListener('click', (e) => {
    const toggle = e.target.closest('.js-tabs-accordion-toggle');

    if (!toggle) return;

    const parent = toggle.closest('.js-tabs-pane');

    if (parent.classList.contains('is-opened')) {
      parent.classList.remove('is-opened');
    } else {
      parent.classList.add('is-opened');
    }
  });
  /* /Tabs Accordeon */

  /* Go To Full Params Tab */
  const goToTabToggle = document.querySelector('[data-goto-tab]');

  if (goToTabToggle) {
    goToTabToggle.addEventListener('click', ({ target }) => {
      const hash = target.dataset.gotoTab;

      let hashTab = document.querySelector('.js-tabs-trigger[href="' + hash + '"]');
      let hashAccordion = document.querySelector(hash);

      if (hashTab) {
        let ev = new Event('click');
        hashTab.dispatchEvent(ev);
      }

      if (hashAccordion) {
        document.querySelectorAll('.js-tabs-pane').forEach(item => item.classList.remove('is-opened'));

        hashAccordion.parentNode.classList.add('is-opened');
      }
    });
  }
  /* Go To Full Params Tab */
  /* ------------ Tabs ------------ */

  /* ========================= JS Dropdown ========================= */
  document.addEventListener('click', (e) => {
    const dropdownToggle = e.target.closest('.js-dropdown-toggle');

    if (!dropdownToggle) return;

    const dropdownContainer = dropdownToggle.closest('.js-dropdown');

    if (!dropdownContainer.classList.contains('is-opened')) {
      document.querySelectorAll('.js-dropdown').forEach(item => item.classList.remove('is-opened'));

      document.body.classList.remove('is-dropdown-opened');
      document.body.classList.remove('is-navbar-opened');
      document.body.classList.remove('is-catalog-expanded');

      if (window.outsideClickListener) {
        document.removeEventListener('click', outsideClickListener);
      }

      dropdownContainer.classList.add('is-opened');

      if (dropdownContainer.classList.contains('has-overlay')) {
        addOverlay();
      }

      if (dropdownContainer.classList.contains('is-lock')) {
        document.body.classList.add('is-dropdown-opened');
      }

      handleClickOutside(dropdownContainer, () => {
        const openedDropdownParents = document.querySelectorAll('.js-dropdown.is-opened');

        openedDropdownParents.forEach((dropdownToggle) => {
          dropdownToggle.classList.remove('is-opened');
        });

        removeOverlay();
        document.body.classList.remove('is-dropdown-opened');
      });
    } else {
      dropdownContainer.classList.remove('is-opened');
      removeOverlay();
      document.body.classList.remove('is-dropdown-opened');
      document.removeEventListener('click', outsideClickListener);
    }
  });
  /* ========================= /JS Dropdown ========================= */

  /* ========================= Navbar ========================= */
  const toggleNavbar = document.querySelector('.js-top-nav-trigger');

  /* Toggler Navbar */
  if (toggleNavbar) {
    toggleNavbar.addEventListener('click', () => {
      const body = document.body;

      body.classList.remove('is-catalog-expanded');

      if (!body.classList.contains('is-navbar-opened')) {
        body.classList.add('is-navbar-opened');
      } else {
        body.classList.remove('is-navbar-opened');
      }
    });
    /* Toggler Navbar */

    /* Toggles Deep Levels Inside */
    // create toggles
    const navbarLinks = document.querySelectorAll('.top-nav a');
    // let navbarLinks = document.querySelectorAll('.navbar .icon');

    navbarLinks.forEach((item) => {
      if (item.closest('li').querySelector('ul')) {
        item.classList.add('has-dropdown');
      }
    });

    const dropdownToggles = document.querySelectorAll('.top-nav .has-dropdown');

    if (window.matchMedia('(max-width: 767px)').matches) {
      dropdownToggles.forEach((item) => {
        item.addEventListener('click', (e) => {
          item.closest('li').classList.toggle('is-opened');

          e.preventDefault();
        });
      });
    }
    /* /Toggles Deep Levels Inside */
  }
  /* ========================= /Navbar ========================= */

  /* ------------ Carousels ------------ */
  const mainCarousel = new Swiper('.js-main-carousel', {
    loop: true,
    slidesPerView: 1,
    // spaceBetween: 10,
    autoHeight: true,

    pagination: {
      el: '.js-main-carousel-pagination',
      clickable: true,
    },

    autoplay: {
      delay: 5000,
    },

    navigation: {
      prevEl: '.js-main-carousel-prev',
      nextEl: '.js-main-carousel-next',
    },
  });

  const sectionCarousels = document.querySelectorAll('.js-section-carousel');

  if (sectionCarousels) {
    sectionCarousels.forEach(initializeCarouselInstance);
  }
  
  const brandsCarousel = new Swiper('.js-brands-carousel', {
    slidesPerView: 1.67,
    spaceBetween: 20,

    grid: {
      rows: 2,
      fill: 'row',
    },

    pagination: {
      el: '.js-brands-carousel-pagination',
      clickable: true,
    },

    navigation: {
      prevEl: '.js-brands-carousel-prev',
      nextEl: '.js-brands-carousel-next',
    },

    breakpoints: {
      480: {
        slidesPerView: 2.6,
        spaceBetween: 20,
      },
      576: {
        slidesPerView: 3.6,
        spaceBetween: 20,
      },
      768: {
        slidesPerView: 4.6,
        spaceBetween: 25,
      },
      992: {
        slidesPerView: 5,
        spaceBetween: 30,
      },
      1200: {
        slidesPerView: 6,
        spaceBetween: 30,
      }
    }
  });

  const testimonialsCarousel = new Swiper('.js-testimonials-carousel', {
    slidesPerView: 1,
    spaceBetween: 15,
    loop: true,

    navigation: {
      prevEl: '.js-testimonials-carousel-prev',
      nextEl: '.js-testimonials-carousel-next',
    },

    pagination: {
      el: '.js-testimonials-carousel-pagination',
      clickable: true,
    },

    breakpoints: {
      768: {
        slidesPerView: 2,
        spaceBetween: 25,
      },
      992: {
        slidesPerView: 2,
        spaceBetween: 40,
      },
      1200: {
        slidesPerView: 2,
        spaceBetween: 50,
      }
    }
  });

  const docsCarousel = new Swiper('.js-docs-carousel', {
    slidesPerView: 2,
    spaceBetween: 15,
    rewind: true,

    navigation: {
      prevEl: '.js-docs-carousel-prev',
      nextEl: '.js-docs-carousel-next',
    },

    pagination: {
      el: '.js-docs-carousel-pagination',
      clickable: true,
    },

    breakpoints: {
      480: {
        slidesPerView: 3,
        spaceBetween: 20,
      },
      768: {
        slidesPerView: 4,
        spaceBetween: 20,
      },
      992: {
        slidesPerView: 5,
        spaceBetween: 25,
      }
    }
  });
  /* ------------ /Carousels ------------ */

  /* ------------ Modal Wins ------------ */
  let modalInstance = null;

  document.addEventListener('click', (e) => {
    let target = e.target.closest('[data-modal-win-trigger]');

    if (!target) return;

    let winId = target.dataset.modalWinTrigger;

    if (modalInstance) {
      modalInstance.close();
    }

    var afterOpen = new Function (target.dataset.afterOpen);
    var beforeClose = new Function (target.dataset.beforeClose);
    var closeOutside = target.dataset.closeOutside ? (target.dataset.closeOutside?.toLowerCase?.() === 'true') : true;

    modalInstance = new Modal({
      content: document.querySelector('[data-modal-win="' + winId + '"]'),
      className: `modal-win__main--${winId}`,
      closeOutside: closeOutside,
      afterOpen: () => {
        afterOpen();
        document.body.style.paddingRight = scrollWidth() + 'px';
      },
      beforeClose: () => {
        beforeClose();
        document.body.style.paddingRight = '';
      }
    });

    modalInstance.open();

    e.preventDefault();
  });

  /* close btn */
  document.addEventListener('click', (e) => {
    const trigger = e.target.closest('.js-modal-close');

    if (!trigger) return;

    const closeBtn = trigger.closest('.modal-win').querySelector('.modal-win__close');

    if (closeBtn) {
      closeBtn.click();
    }
  });
  /* /close btn */
  /* ------------ /Modal Wins ------------ */

  /* ------------ LightGallery ------------ */
  document.querySelectorAll('.js-gallery').forEach((gallery) => {
    lightGallery(gallery, {
      selector: 'a',
      download: false,
    });
  });
  /* ------------ /LightGallery ------------ */

  /* ------------ Testimonials Section ------------ */
  document.addEventListener('click', ({ target }) => {
    const testimonialsTrigger = target.closest('.js-testimonials-trigger');

    if (!testimonialsTrigger) return;

    const body = document.body;

    body.classList.add('is-testimonials-opened');
    addOverlay();

    const testimonialsSection = document.querySelector('.testimonials-section');

    handleClickOutside(testimonialsSection, () => {
      body.classList.remove('is-testimonials-opened');
      removeOverlay();
    });
  });

  document.addEventListener('click', ({ target }) => {
    const testimonialsCloseButton = target.closest('.js-testimonials-close');

    if (!testimonialsCloseButton) return;

    document.body.classList.remove('is-testimonials-opened');
    removeOverlay();
    document.removeEventListener('click', outsideClickListener);
  });
  /* ------------ /Testimonials Section ------------ */

  /* ------------ Tippy JS ------------ */
  tippy.delegate('body', {
    target: '[data-tippy-content]',
    theme: 'light-border',
    // trigger: 'click',
    allowHTML: true,
    content(ref) {
      const template = ref.querySelector('[data-tippy-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-content');
    },
  });

  /*
  tippy('[data-tippy-content]', {
    theme: 'light-border',
    // trigger: 'click',
    allowHTML: true,
    content(ref) {
      const template = ref.querySelector('[data-tippy-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-content');
    },
  });
  */

  tippy.delegate('body', {
    target: '[data-tippy-gray-content]',
    theme: 'is-gray',
    // trigger: 'click',
    allowHTML: true,
    content(ref) {
      const template = ref.querySelector('[data-tippy-gray-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-gray-content');
    },
  });

  /*
  tippy('[data-tippy-gray-content]', {
    theme: 'is-gray',
    // trigger: 'click',
    allowHTML: true,
    content(ref) {
      const template = ref.querySelector('[data-tippy-gray-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-gray-content');
    },
  });
  */

  tippy('[data-template-articul]', {
    theme: 'light-border',
    interactive: true,
    trigger: 'click',
    placement: 'top-end',
    allowHTML: true,
    arrow: false,
    boundary: HTMLElement,
    appendTo: 'parent',
    popperOptions: {
      positionFixed: true,
    },
    content(reference) {
      const parent = reference.parentNode;
      const template = parent.querySelector('[data-tooltip-content]');
  
      if (template) {
        return template.innerHTML;
      }
    },
  });

  /**
   * Interactive Versions
   */
  tippy.delegate('body', {
    target: '[data-tippy-interactive-content]',
    theme: 'light-border',
    // trigger: 'click',
    interactive: true,
    appendTo: document.body,
    allowHTML: true,
    content(ref) {
      const template = ref.querySelector('[data-tippy-interactive-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-interactive-content');
    },
  });

  tippy.delegate('body', {
    target: '[data-tippy-interactive-gray-content]',
    theme: 'is-gray',
    // trigger: 'click',
    interactive: true,
    appendTo: document.body,
    allowHTML: true,
    content(ref) {
      const template = ref.querySelector('[data-tippy-interactive-gray-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-interactive-gray-content');
    },
  });

  tippy.delegate('body', {
    target: '[data-tippy-dropdown-content]',
    theme: 'light-border',
    trigger: 'click',
    interactive: true,
    appendTo: document.body,
    allowHTML: true,
    content(ref) {
      const template = ref.querySelector('[data-tippy-dropdown-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-dropdown-content');
    },
  });
  /* ------------ Tippy JS ------------ */

  /* Choices Default */
  const choices = document.querySelectorAll('.js-select-default');

  choices.forEach(choice => {
    new Choices(choice, {
      delimiter: ',',
      searchEnabled: false,
      itemSelectText: '',
      shouldSort: false,
      placeholder: true,
    });
  });
  /* /Choices Default */

  /* Autocomplete Type */
  const choicesAutocomplete = document.querySelectorAll('.js-select-autocomplete');

  choicesAutocomplete.forEach(choice => {
    new Choices(choice, {
      delimiter: ',',
      itemSelectText: '',
      noResultsText: 'Ничего не найдено!',
    });
  });
  /* /Autocomplete Type */
  
  
  /* ------------ UI Slider Range ------------ */
  initSliders();
  /* ------------ UI Slider Range ------------ */

  /* ------------ Filter ------------ */
  /* Show more */
  let filterMoreToggles = document.querySelectorAll('.filter__more-options');

  filterMoreToggles.forEach(function(item) {
    item.addEventListener('click', function(e) {
      let parent = e.target.closest('.filter__section');
      let textNode = this.children[0];
      
      if ( parent.classList.contains('is-fields-on') ) {
        parent.classList.remove('is-fields-on');
        textNode.innerHTML = 'Показать все';
      } else {
        parent.classList.add('is-fields-on');
        textNode.innerHTML = 'Скрыть';
      }

      e.preventDefault();
    });
  });
  /* Show more */

  /* Collapse all */
  document.addEventListener('pointerdown', (e) => {
    const toggler = e.target.closest('.filter__collapse');

    if (!toggler) return;

    e.preventDefault();

    const filter = document.querySelector('.filter');

    if (filter.classList.contains('is-collapsed')) {
      document.querySelectorAll('.filter__section').forEach((field) => {
        field.classList.add('is-opened');
      });

      toggler.innerHTML = 'Свернуть все';
      filter.classList.remove('is-collapsed');
    } else {
      document.querySelectorAll('.is-fields-on').forEach((field) => {
        field.classList.remove('is-fields-on');
        field.querySelector('.filter__more-options-amount').innerHTML = 'Показать все';
      });

      document.querySelectorAll('.filter__section').forEach((field) => {
        field.classList.remove('is-opened');
      });

      toggler.innerHTML = 'Развернуть все';
      filter.classList.add('is-collapsed');
    }
  })
  /* Collapse all */

  /* Filter-Mobile */
  let filterToggle = document.querySelector('.filter-toggle');

  if (filterToggle) {
    filterToggle.addEventListener('click', function(e) {
      let body = document.body;

      if ( !body.classList.contains('is-filter-opened') ) {
        addOverlay();
        body.classList.add('is-filter-opened');
        body.style.paddingRight = scrollWidth() + 'px';

        setTimeout(function() {
          document.addEventListener('click', clickOutsideFilter);
        });
      }

      e.preventDefault();
    });
  }

  let filterClose = document.querySelector('.filter__close');

  if (filterClose) {
    filterClose.addEventListener('click', function(e) {
      let target = e.target.closest('.filter');

      if (!target ) return;

      removeOverlay();
      document.body.classList.remove('is-filter-opened');
      document.body.style.paddingRight = '';

      document.removeEventListener('click', clickOutsideFilter);
    });
  }

  function clickOutsideFilter(e) {
    let target = e.target.closest('.filter');
    let datePicker = e.target.closest('.flatpickr-calendar');

    if (target || datePicker) return;

    removeOverlay();
    document.body.classList.remove('is-filter-opened');
    document.body.style.paddingRight = '';

    document.removeEventListener('click', clickOutsideFilter);
  }
  /* Filter-Mobile */

  /* Filter-Toggle-Section */
  document.addEventListener('click', function(e) {
    let target = e.target.closest('.filter__title');

    if (!target) return;

    target.closest('.filter__section').classList.toggle('is-opened');

    document.querySelectorAll('.filter').forEach(item => { item.classList.remove('is-collapsed'); })
    document.querySelectorAll('.filter__collapse').forEach(item => { item.innerHTML = 'Свернуть все' });
  });
  /* Filter-Toggle-Section */
  /* ------------ Filter ------------ */

  /* ------------ Handle Click Outside ------------ */
  function handleClickOutside(elem, callback) {
    // const outsideClickListener = ev => {
    window.outsideClickListener = ev => {
      // if (!ev.target.closest(elem)) {
      if (!elem.contains(event.target) && isElemVisible(elem)) {
        if (typeof callback === 'function') {
          callback();
        }

        removeClickListener();
      }
    }

    const removeClickListener = () => {
      document.removeEventListener('click', outsideClickListener);
    }

    document.addEventListener('click', outsideClickListener)
  }
  /* ------------ /Handle Click Outside ------------ */

  /* ------------ Product-Main ------------ */
  const galleryThumbs = new Swiper('.js-thumbs-list', {
    slidesPerView: 3,
    spaceBetween: 15,

    watchSlidesVisibility: true,
    watchSlidesProgress: true,

    slideToClickedSlide: true,
    touchRatio: 0.2,

    breakpoints: {
      768: {
        direction: 'vertical',
        spaceBetween: 15,
      },
      992: {
        direction: 'vertical',
        spaceBetween: 20,
      },
    },

    navigation: {
      prevEl: '.js-thumbs-list-prev',
      nextEl: '.js-thumbs-list-next',
    }
  });

  const galleryMain = new Swiper('.js-promo-main', {
    spaceBetween: 20,
    // effect: 'coverflow',

    watchSlidesVisibility: true,
    watchSlidesProgress: true,

    /*
    pagination: {
      el: '.js-promo-main-pagination',
      clickable: true,
    },
    */

    thumbs: {
      swiper: galleryThumbs,
    },
  });

  galleryMain.on('slideChangeTransitionStart', () => {
    galleryThumbs.slideTo(galleryMain.activeIndex);
  });

  galleryThumbs.on('transitionStart', () => {
    //if (galleryThumbs.isEnd) return;

    galleryMain.slideTo(galleryThumbs.activeIndex);
  });

  lightGallery(document.querySelector('.js-promo-main'), {
    selector: 'a',
    download: false,
  });

  /* Drift Zoom */
  if (window.matchMedia('(min-width: 768px)').matches) {
    const driftPaneContainer = document.querySelector('.js-gallery-zoom-pane');
    let driftInstance = null;

    initDriftZoom(document.querySelector('.js-promo-main .swiper-slide-active img'), driftPaneContainer);

    galleryMain.on('slideChange', function() {
      setTimeout(() => {
        driftInstance.destroy();

        initDriftZoom(document.querySelector('.js-promo-main .swiper-slide-active img'), driftPaneContainer);
      });
    });

    function initDriftZoom(driftTriggerElement, driftPaneContainer) {
      if ( !driftTriggerElement ) return;
      
      driftInstance = new Drift(driftTriggerElement, {
        paneContainer: driftPaneContainer,
        hoverBoundingBox: true,
        zoomFactor: 3,
        inlinePane: false,
        handleTouch: false,
      });
    }
  }
  /* Drift Zoom */
  /* ------------ /Product-Main ------------ */

  /* ------------ Brand Gallery ------------ */
  const brandsThumbs = new Swiper('.js-brands-thumbs-list', {
    slidesPerView: 3,
    spaceBetween: 15,

    watchSlidesVisibility: true,
    watchSlidesProgress: true,

    slideToClickedSlide: true,
    touchRatio: 0.2,

    pagination: {
      el: '.js-brands-thumbs-list-pagination',
      clickable: true,
    },

    breakpoints: {
      576: {
        spaceBetween: 15,
        slidesPerView: 4,
      },
      768: {
        spaceBetween: 20,
        slidesPerView: 5,
      },
      992: {
        spaceBetween: 30,
        slidesPerView: 6,
      },
    },

    navigation: {
      prevEl: '.js-brands-thumbs-list-prev',
      nextEl: '.js-brands-thumbs-list-next',
    }
  });

  const brandsMain = new Swiper('.js-brands-promo-main', {
    spaceBetween: 20,
    // effect: 'coverflow',

    watchSlidesVisibility: true,
    watchSlidesProgress: true,

    autoHeight: true,

    /*
    pagination: {
      el: '.js-brands-promo-main-pagination',
      clickable: true,
    },
    */

    thumbs: {
      swiper: brandsThumbs,
    },
  });

  // brandsMain.on('slideChangeTransitionStart', () => {
  brandsMain.on('slideChange', () => {
    brandsThumbs.slideTo(brandsMain.activeIndex);
  });

  // brandsThumbs.on('transitionStart', () => {
  brandsThumbs.on('slideChange', () => {
    //if (brandsThumbs.isEnd) return;

    brandsMain.slideTo(brandsThumbs.activeIndex);
  });
  /* ------------ /Brand Gallery ------------ */

  /* ------------ Is Element Visible ------------ */
  const isElemVisible = elem => !!elem && !!(elem.offsetWidth || elem.offsetHeight || elem.getClientRects().length);
  /* ------------ /Is Element Visible ------------ */

  /* ------------ is touch helper ------------ */
  if ('ontouchstart' in window || navigator.msMaxTouchPoints) {
    document.documentElement.classList.add('is-touch');
  }
  /* ------------ /is touch helper ------------ */

  /* ------------ header height ------------ */
  const headerTopHeight = () => {
    const doc = document.documentElement;
    const headerTop = document.querySelector('.header__top');

    if (!headerTop) return;

    const headerAvailableHeight = Math.max(parseInt(headerTop.offsetHeight) + headerTop.getBoundingClientRect().top, 0);

    doc.style.setProperty('--headerTopHeight', `${headerAvailableHeight}px`);
  }

  window.addEventListener('resize', debounce(headerTopHeight, 200));
  window.addEventListener('scroll', debounce(headerTopHeight, 200));
  headerTopHeight();
  /* ------------ /header height ------------ */

  /* ------------ iOS vh bug ------------ */
  const appHeight = () => {
    const doc = document.documentElement;
    const vh = window.innerHeight * 0.01;

    doc.style.setProperty('--vh', `${vh}px`);
  }

  window.addEventListener('resize', appHeight);
  appHeight();
  /* ------------ /iOS vh bug ------------ */

  /* -------- Accordions --------- */
  document.addEventListener('click', (e) => {
    const accordionTrigger = e.target.closest('.js-accordion-trigger');

    if (!accordionTrigger) return;

    e.preventDefault();

    const parent = accordionTrigger.closest('.js-accordion');
    const pane = parent.querySelector('.js-accordion-body');

    if (parent.classList.contains('is-active')) {
      slideUp(pane, 500, () => {
        parent.classList.remove('is-active');
      });
    } else {
      slideDown(pane, 500, () => {
        parent.classList.add('is-active');
      });
    }
  });
  /* -------- /Accordions --------- */

  /* -------- More Behaviour --------- */
  document.addEventListener('click', ({ target }) => {
    const moreBtn = target.closest('.js-more-btn');

    if (!moreBtn) return;

    const moreText = moreBtn.dataset.moreText ? moreBtn.dataset.moreText : 'Развернуть';
    const lessText = moreBtn.dataset.lessText ? moreBtn.dataset.lessText : 'Свернуть';

    const textStates = {
      more: moreText,
      less: lessText,
    };

    showMore(moreBtn, textStates);
  });

  function showMore(btn, texts) {
    const parent = btn.closest('.js-more-parent');
    const btnText = btn.children[0] ? btn.children[0] : btn;

    if (parent.classList.contains('is-expanded')) {
      parent.classList.remove('is-expanded');
      btnText.textContent = texts.more;
    } else {
      parent.classList.add('is-expanded');
      btnText.textContent = texts.less;
    }
  }
  /* -------- /More Behaviour --------- */

  /* -------- Footer Collapse --------- */
  document.querySelector('.footer').addEventListener('click', ({ target }) => {
    const footerCollapseTrigger = target.closest('.js-footer-collapse');

    if (!footerCollapseTrigger) return;

    footerCollapseTrigger.parentNode.classList.toggle('is-expanded');
  });
  /* -------- /Footer Collapse --------- */

  /* ------------ Counter ------------ */
  document.querySelectorAll('.counter').forEach(counter => {
    counter.addEventListener('click', ({ target }) => {
      const button = target.closest('[data-action]');
      
      if (!button) return;

      const mode = button.dataset.action;
      const input = counter.querySelector('input');
      const value = input.value;

      switch (mode) {
        case 'remove':
          if (value > 1) {
            input.value = parseInt(value) - 1;
          }

          break;
        case 'add':
          if (parseInt(input.value) < 999) {
            input.value = parseInt(value) + 1;
          }

          break;
      }
	  input.onchange();
  
    });
  });
  /* ------------ /Counter ------------ */

  /* ------------ Date Pickers ------------ */
  flatpickr.localize(flatpickr.l10ns.ru);
  // flatpickr.l10ns.default.firstDayOfWeek = 1;

  flatpickr('.js-date-picker', {
    dateFormat: 'd.m.Y',
    ariaDateFormat: 'd.m.Y',
    monthSelectorType: 'static',
    // disableMobile: true,
    prevArrow: '<svg viewBox="0 0 24 24" width="24" height="24"><path d="M14.411 19.021l-6.288-6.287a1.013 1.013 0 010-1.467l6.288-6.288a1.013 1.013 0 011.467 0 1.013 1.013 0 010 1.467L10.324 12l5.554 5.554a1.013 1.013 0 010 1.467 1.013 1.013 0 01-1.467 0z"/></svg>',
    nextArrow: '<svg viewBox="0 0 24 24" width="24" height="24"><path d="M9.591 19.021l6.286-6.287a1.013 1.013 0 000-1.469L9.591 4.979a1.013 1.013 0 00-1.467 0 1.013 1.013 0 000 1.467L13.676 12l-5.554 5.554a1.038 1.038 0 101.469 1.467z"/></svg>',
  });
  /* ------------ /Date Pickers ------------ */

  /* -------- Light Galleries --------- */
  document.querySelectorAll('.js-item-gallery').forEach((item) => {
    lightGallery(item, {
      selector: 'this',
      download: false,
    });
  });
  /* -------- /Light Galleries --------- */

  /* -------- Spec Catalog Table Collapse -------- */
  document.addEventListener('change', ({ target }) => {
    const toggleAllSpecs = target.closest('.js-spec-params-all-trigger');

    if (!toggleAllSpecs) return;

    const specTableParams = document.querySelectorAll('.spec-table-params');

    specTableParams.forEach(specTableParam => {
      const specButtonText = specTableParam.querySelector('.btn__text');

      if (toggleAllSpecs.checked) {
        specTableParam.classList.add('is-params-expanded');

        if (specButtonText) {
          specButtonText.innerHTML = 'Свернуть';
        }
      } else {
        specTableParam.classList.remove('is-params-expanded');

        if (specButtonText) {
          specButtonText.innerHTML = 'Спецификации';
        }
      }
    });
  });

  document.addEventListener('click', ({ target }) => {
    const specParamsTrigger = target.closest('.js-spec-params-trigger');

    if (!specParamsTrigger) return;

    document.querySelectorAll('.js-spec-params-all-trigger').forEach(checkbox => checkbox.checked = false);

    const parent = specParamsTrigger.parentNode;

    if (!parent) return;

    if (parent.classList.contains('is-params-expanded')) {
      parent.classList.remove('is-params-expanded');

      if (specParamsTrigger.children[0]) {
        specParamsTrigger.children[0].textContent = 'Спецификации';
      }
    } else {
      parent.classList.add('is-params-expanded');

      if (specParamsTrigger.children[0]) {
        specParamsTrigger.children[0].textContent = 'Свернуть';
      }
    }
  });
  /* -------- /Spec Catalog Table Collapse -------- */

  /* Product Detail Filter Checkbox */
  document.addEventListener('click', (e) => {
    const priceFilterCheckbox = e.target.closest('.js-col-switch');

    if (!priceFilterCheckbox) return;

    const value = priceFilterCheckbox.value;

    const parent = document.querySelector('.data-table');
    const buyCols = document.querySelectorAll('[data-col-buy]');
    const sellCols = document.querySelectorAll('[data-col-sell]');

    switch (value) {
      case 'buy':
        buyCols.forEach(col => col.hidden = false);
        sellCols.forEach(col => col.hidden = true);
        parent.classList.add('has-buy-col');
        parent.classList.remove('has-sell-col');
        break;
      case 'sell':
        buyCols.forEach(col => col.hidden = true);
        sellCols.forEach(col => col.hidden = false);
        parent.classList.add('has-sell-col');
        parent.classList.remove('has-buy-col');
        break;
      case 'both':
        buyCols.forEach(col => col.hidden = false);
        sellCols.forEach(col => col.hidden = false);
        parent.classList.remove('has-sell-col', 'has-buy-col');
        break;
    }
  });
  /* Product Detail Filter Checkbox */

  /* toggle all checkboxes */
  const checkAllControls = document.querySelectorAll('.js-checked-all-trigger');

  checkAllControls.forEach(checkAllControl => {
    checkAllControl.addEventListener('change', ({ target }) => {
      const parent = target.closest('.js-checked-all');
      const checkboxes = parent.querySelectorAll('.js-checked-all-item, .js-checked-all-trigger');

      checkboxes.forEach(checkbox => checkbox.checked = target.checked);
    });
  });

  document.addEventListener('change', ({ target }) => {
    if (!target.classList.contains('js-checked-all-item')) return;

    let parent = target.closest('.js-checked-all');

    while(parent) {
      parent.querySelector('.js-checked-all-trigger').checked = false;
      parent = parent.parentNode.closest('.js-checked-all');
    }

    /*
    let parent = target.closest('.js-checked-all');
    parent.querySelector('.js-checked-all-trigger').checked = false;

    parent = parent.closest('.js-checked-all');

    if (parent) {
      parent.querySelector('.js-checked-all-trigger').checked = false;
    }
    */
  });
  /* toggle all checkboxes */

  /* privacy btn state */
  const checkboxSubmitStatus = document.querySelector('.js-privacy-state-trigger');
  
  if (checkboxSubmitStatus) {
    checkboxSubmitStatus.addEventListener('change', ({ currentTarget }) => {
      const submitBtn = document.querySelector('.js-privacy-state-btn');
    
      submitBtn.disabled = !currentTarget.checked;
    });
  }
  /* /privacy btn state */

  /* sidebar-trigger */
  const sidebarTrigger = document.querySelector('.js-sidebar-trigger');

  if (sidebarTrigger) {
    sidebarTrigger.addEventListener('click', (e) => {
      const parent = e.target.closest('.primary');

      if (!parent) return;

      parent.classList.toggle('is-full');
    });
  }
  /* /sidebar-trigger */

  /* ============== js-more-trigger ============== */
  document.addEventListener('click', ({ target }) => {
    const moreTrigger = target.closest('.js-more-trigger');

    if (!moreTrigger) return;

    const parent = moreTrigger.parentNode;

    const moreTriggerTextNode = (moreTrigger.querySelector('span')) ? moreTrigger.querySelector('span') : moreTrigger;

    if (parent.classList.contains('is-expanded')) {
      parent.classList.remove('is-expanded');
      moreTriggerTextNode.textContent = 'Показать еще';
    } else {
      parent.classList.add('is-expanded');
      moreTriggerTextNode.textContent = 'Скрыть';
    }
  });
  /* ============== /js-more-trigger ============== */

  /* ============== js-mode-trigger ============== */
  const modeTrigger = document.querySelector('.js-mode-trigger');

  if (modeTrigger) {
    modeTrigger.addEventListener('change', ({ target }) => {
      const tableMode = target;
      const parent = document.querySelector('.stock-area');

      if (tableMode.checked) {
        parent.classList.remove('is-table-view');
        parent.classList.add('is-line-view');
      } else {
        parent.classList.add('is-table-view');
        parent.classList.remove('is-line-view');
      }
    });
  }
  /* ============== /js-mode-trigger ============== */

  /* ============== js inner trigger ============== */
  document.addEventListener('click', ({ target }) => {
    const innerMobTableBtn = target.closest('.js-inner-table-trigger');

    if (!innerMobTableBtn) return;

    const parent = innerMobTableBtn.closest('.js-inner-table');
    const btns = parent.querySelectorAll('.js-inner-table-trigger');

    if (parent.classList.contains('is-active')) {
      parent.classList.remove('is-active');
      btns.forEach(btn => btn.querySelector('span').textContent = 'Показать позиции заказа');
    } else {
      parent.classList.add('is-active');
      btns.forEach(btn => btn.querySelector('span').textContent = 'Скрыть позиции заказа');
    }
  });
  /* ============== /js inner trigger ============== */

  /* footer popup window */
  const footerPopupTrigger = document.querySelector('.js-callback-popup-trigger');

  if (footerPopupTrigger) {
    footerPopupTrigger.addEventListener('click', (e) => {
      e.preventDefault();

      const body = document.body;

      const closeWinTrigger = document.querySelector('.footer-popup__close');
      closeWinTrigger.addEventListener('click', closePopupWin);

      if (body.classList.contains('is-popup-opened')) {
        closePopupWin();
      } else {
        body.classList.add('is-popup-opened');
        body.style.paddingRight = scrollWidth() + 'px';
        addOverlay();

        document.addEventListener('mousedown', footerPopupCheckClickOutside);
      }
    });
  }

  function closePopupWin() {
    const body = document.body;

    body.classList.remove('is-popup-opened');
    body.style.paddingRight = '';
    removeOverlay();

    document.removeEventListener('mousedown', footerPopupCheckClickOutside);
  }

  function footerPopupCheckClickOutside(e) {
    const target = e.target.closest('.footer-popup');

    if (target) return;

    closePopupWin();
  }
  /* /footer popup window */

  document.addEventListener('click', (e) => {
    const regionsTrigger = e.target.closest('.js-regions-trigger');

    if (!regionsTrigger) return;

    document.body.classList.remove('is-main-nav-opened', 'is-navbar-opened', 'is-modal-contacts-active', 'is-mob-search-opened');
    document.body.classList.add('is-regions-opened');
  });

  document.addEventListener('click', (e) => {
    const regionsTriggerClose = e.target.closest('.mob-regions__close');

    if (!regionsTriggerClose) return;

    document.body.classList.remove('is-regions-opened');
  });

  document.addEventListener('click', (e) => {
    const mobContactsTrigger = e.target.closest('.js-mob-contacts');

    if (!mobContactsTrigger) return;

    e.preventDefault();

    document.body.classList.add('is-modal-contacts-active');
    addOverlay();
  });

  document.addEventListener('click', (e) => {
    const mobContactsClose = e.target.closest('.header-mob-contacts__close');

    if (!mobContactsClose) return;

    e.preventDefault();

    document.body.classList.remove('is-modal-contacts-active');
    removeOverlay();
  });

  const navTrigger = document.querySelector('.navigation-trigger');

  if (navTrigger) {
    navTrigger.addEventListener('click', function() {
      document.body.classList.toggle('is-main-nav-opened');
    })
  }

  /* --- STICKY HEADER --- */
  const headerSticky = document.querySelector('.header-meta-area');
  let stickyOffset = headerSticky.offsetTop;

  window.onscroll = checkScroll;
  checkScroll();

  function checkScroll() {
    if (window.pageYOffset > stickyOffset) {
      document.body.classList.add('is-sticky');
      document.body.style.paddingTop = headerSticky.offsetHeight + 'px';
    } else {
      document.body.classList.remove('is-sticky');
      document.body.style.paddingTop = '';
    }
  }
  /* --- STICKY HEADER --- */

  /* header-mob-nav */
  document.addEventListener('click', (e) => {
    const target = e.target.closest('.mob-nav__link.has-dropdown');

    if (!target) return;

    e.preventDefault();

    target.parentNode.classList.toggle('is-active');
  });
  /* /header-mob-nav */

  /* ------------ Catalog-Navbar ------------ */
  document.querySelector('.catalog-nav-toggle').addEventListener('click', function() {
    let body = document.body;

    if ( !body.classList.contains('is-navbar-opened') ) {
      body.classList.add('is-navbar-opened');
      body.style.paddingRight = scrollWidth() + 'px';
      // addOverlay();

      setTimeout(function() {
        document.addEventListener('click', clickOutsideNavbar);
      });
    }
  });

  function clickOutsideNavbar(e) {
    let target = e.target.closest('.main-nav');

    if (target) return;

    document.body.classList.remove('is-navbar-opened');
    document.body.style.paddingRight = '';
    // removeOverlay();
    document.removeEventListener('click', clickOutsideNavbar);
  }

  /* Toggles Inside */
  // create toggles
  let navbarLinks = document.querySelectorAll('.main-nav__container .main-nav__link');

  navbarLinks.forEach(function(item) {
    if ( item.closest('li').querySelector('ul') ) {
      item.classList.add('has-dropdown');
    }
  });

  let dropdownToggles = document.querySelectorAll('.main-nav .has-dropdown');

  dropdownToggles.forEach(function(item) {
    item.addEventListener('click', function(e) {
      item.closest('li').classList.toggle('is-opened');

      e.preventDefault();
    });
  });
  /* Toggles Inside */
  /* ------------ Catalog-Navbar ------------ */

  /* ------------ Mob Nav ------------ */
  document.querySelector('.mob-nav').addEventListener('click', (e) => {
    const target = e.target.closest('.mob-nav__link');

    if (!target) return;

    if (!target.closest('.has-dropdown')) return;

    e.preventDefault();

    target.parentNode.classList.toggle('is-opened');
  });
  /* ------------ Mob Nav ------------ */

  /* ------------ Authorize-Dropdown ------------ */
  if (document.querySelector('.authorize__link--login')) {
    document.querySelector('.authorize__link--login').addEventListener('click', function(e) {
      let parent = this.closest('.authorize');

      if ( !parent.classList.contains('is-dropdown-opened') ) {
        parent.classList.add('is-dropdown-opened');

        setTimeout(function() {
          document.addEventListener('click', clickOutsideAuthorize);
        });
      }

      e.preventDefault();
    });

    function clickOutsideAuthorize(e) {
      let target = e.target.closest('.authorize__dropdown');

      if (target) return;

      document.querySelector('.authorize').classList.remove('is-dropdown-opened');

      document.removeEventListener('click', clickOutsideAuthorize);
    }
  }
  /* ------------ Authorize-Dropdown ------------ */

  const searchTypeSelect = new Choices('.js-select-search', {
    delimiter: ',',
    searchEnabled: false,
    itemSelectText: '',
    shouldSort: false,
  });

  searchTypeSelect.passedElement.element.addEventListener('change', function(e) {
    const value = e.target.value;
    const searchInput = document.querySelector('.search-form__input');

    switch (value) {
      case 'articul':
        searchInput.placeholder = 'Номер артикула'
        break;
      case 'title':
        searchInput.placeholder = 'Наименование'
        break;
      case 'vin':
        searchInput.placeholder = 'VIN'
        break;
    }
  });

  document.querySelector('.section-nav').addEventListener('mouseenter', (e) => {
    searchTypeSelect.hideDropdown()
  });

  /* informer */
  document.addEventListener('click', (e) => {
    const target = e.target.closest('.top-informer__close');

    if (!target) return;
    
    target.closest('.top-informer').hidden = true;
    stickyOffset = headerSticky.offsetTop;
  });
  /* /informer */

  /* --- Banner --- */
  if (document.querySelector('.header-banner__close')) {
    const bannerToggles = document.querySelectorAll('.header-banner__close');

    bannerToggles.forEach((bannerToggle) => {
      bannerToggle.addEventListener('click', function(e) {
        e.target.closest('.header-banner').hidden = true;

        e.preventDefault();

        stickyOffset = headerSticky.offsetTop;
      });
    });
  }
  /* --- Banner --- */

  /*  ============== Tree Nav ============== */
  // create toggles
  const treeNavLinks = document.querySelectorAll('.tree-nav a');
  // const treeNavLinks = document.querySelectorAll('.navbar .icon');

  treeNavLinks.forEach((item) => {
    if (item.closest('li').querySelector('ul')) {
      item.classList.add('has-dropdown');
    }
  });

  const treeNavToggles = document.querySelectorAll('.tree-nav .has-dropdown');

  treeNavToggles.forEach((item) => {
    item.addEventListener('click', (e) => {
      item.closest('li').classList.toggle('is-opened');

      e.preventDefault();
    });
  });
  /* ============== Tree Nav ============== */
});

/* ------------ Helpers ------------ */
function scrollWidth() {
  const div = document.createElement('div');
  const body = document.body;

  div.style.overflowY = 'scroll';
  div.style.width = '50px';
  div.style.height = '50px';
  div.style.visibility = 'hidden';

  body.appendChild(div);

  const scrollWidth = div.offsetWidth - div.clientWidth;

  body.removeChild(div);

  return scrollWidth;
}

function addOverlay() {
  const overlay = document.createElement('div');
  overlay.className = 'overlay';
  document.body.appendChild(overlay);
}

function removeOverlay() {
  const overlay = document.querySelector('.overlay');

  if (overlay) overlay.remove();
}

function debounce(func, wait, immediate) {
  var timeout;

  return function() {
    var context = this, args = arguments;

    var later = function() {
      timeout = null;
      if (!immediate) func.apply(context, args);
    };

    var callNow = immediate && !timeout;

    clearTimeout(timeout);

    timeout = setTimeout(later, wait);

    if (callNow) func.apply(context, args);
  };
};

function throttle(callback, limit) {
  var waiting = false;                 // Initially, we're not waiting

  return function() {                  // We return a throttled function
    if (!waiting) {                    // If we're not waiting
      callback.apply(this, arguments); // Execute users function
      waiting = true;                  // Prevent future invocations
      setTimeout(function () {         // After a period of time
        waiting = false;               // And allow future invocations
      }, limit);
    }
  }
}

function slideUp(target, duration = 500, callback) {
  if (!target.classList.contains('in-progress')) {
    target.classList.add('in-progress');
    target.style.transitionProperty = 'height, margin, padding';
    target.style.transitionDuration = duration + 'ms';
    target.style.height = `${target.offsetHeight}px`;
    target.offsetHeight;
    target.style.overflow = 'hidden';
    target.style.height = 0;
    target.style.paddingTop = 0;
    target.style.paddingBottom = 0;
    target.style.marginTop = 0;
    target.style.marginBottom = 0;

    window.setTimeout(() => {
      target.hidden = true;
      target.style.removeProperty('height');
      target.style.removeProperty('padding-top');
      target.style.removeProperty('padding-bottom');
      target.style.removeProperty('margin-top');
      target.style.removeProperty('margin-bottom');
      target.style.removeProperty('overflow');
      target.style.removeProperty('transition-duration');
      target.style.removeProperty('transition-property');
      target.classList.remove('in-progress');

      callback();
    }, duration);
  }
}

function slideDown(target, duration = 500, callback) {
  if (!target.classList.contains('in-progress')) {
    target.classList.add('in-progress');
    target.hidden = target.hidden ? false : null;
    let height = target.offsetHeight;
    target.style.overflow = 'hidden';
    target.style.height = 0;
    target.style.paddingTop = 0;
    target.style.paddingBottom = 0;
    target.style.marginTop = 0;
    target.style.marginBottom = 0;
    target.offsetHeight;
    target.style.transitionProperty = 'height, margin, padding';
    target.style.transitionDuration = duration + 'ms';
    target.style.height = height + 'px';
    target.style.removeProperty('padding-top');
    target.style.removeProperty('padding-bottom');
    target.style.removeProperty('margin-top');
    target.style.removeProperty('margin-bottom');

    window.setTimeout(() => {
      target.style.removeProperty('height');
      target.style.removeProperty('overflow');
      target.style.removeProperty('transition-duration');
      target.style.removeProperty('transition-property');
      target.classList.remove('in-progress');

      callback();
    }, duration);
  }
}

function slideToggle(target, duration = 500) {
  if (target.hidden) {
    return slideDown(target, duration);
  } else {
    return slideUp(target, duration);
  }
}

function initializeCarouselInstance (instance) {
	  const parentSection = instance.parentNode;
      const slidesLength = instance.querySelectorAll('.swiper-slide').length;

      const pagination = parentSection.querySelector('.js-section-carousel-pagination');

      const prev = parentSection.querySelector('.js-section-carousel-prev');
      const next = parentSection.querySelector('.js-section-carousel-next');

      const isLoop = slidesLength > 5;

      new Swiper(instance, {
        loop: isLoop,
        slidesPerView: 1,
        spaceBetween: 10,
        watchSlidesProgress: true,

        pagination: {
          el: pagination,
          clickable: true,
        },

        navigation: {
          prevEl: prev,
          nextEl: next,
        },

        breakpoints: {
          440: {
            slidesPerView: 2,
            spaceBetween: 10,
          },
          576: {
            slidesPerView: 3,
            spaceBetween: 10,
          },
          768: {
            slidesPerView: 4,
            spaceBetween: 20,
          },
          992: {
            slidesPerView: 5,
            spaceBetween: 20,
          },
        }
      });
}

function initSliders() {
    /* ------------ UI Slider Range ------------ */
    var sliders = document.querySelectorAll('.js-range-slider');

    if (sliders) {
        sliders.forEach(function (slider) {
            var dataFrom = parseInt(slider.dataset.from) || 0;
            var dataTo = parseInt(slider.dataset.to) || 100;
            var isDecimal = slider.dataset.decimal;
            var rangeStep = isDecimal ? parseFloat(slider.dataset.step || 1000) : parseInt(slider.dataset.step || 1000);
            var parent = slider.parentNode;
            var inputFrom = parent.querySelectorAll('input')[0];
            var inputTo = parent.querySelectorAll('input')[1];
            var inputs = [inputFrom, inputTo]; // numbers format

            var sliderFormat = {
                to: function to(e) {
                    return Math.round(e);
                },
                from: function from(e) {
                    return Number(e);
                }
            };

            if (isDecimal) {
                sliderFormat = {
                    to: function to(e) {
                        return parseFloat(e).toFixed(1);
                    },
                    from: function from(e) {
                        return parseFloat(e).toFixed(1);
                    }
                };
            } // init slider

			var start = [];
			if (dataFrom >= 0)
				start.push(dataFrom);
			if (dataTo >= 0)
				start.push(dataTo);

            noUiSlider.create(slider, {
                start: start,
                connect: true,
                // tooltips: true,
                step: rangeStep,
                range: {
				min: dataFrom || 0,
				max: dataTo || 100
                },
                format: sliderFormat
            }); // sync inputs to the range

            if (inputFrom || inputTo) {
				var min = inputs[0].value;
				var max = inputs[1].value;
				slider.noUiSlider.on('update', function (values, handle) {
				inputs[handle].value = values[handle];
				});
				slider.noUiSlider.on('change', function (values, handle) {
				inputs[handle].value = values[handle];
				});
				if (inputFrom.name) {
					inputFrom.addEventListener('change', function () {
						slider.noUiSlider.set([this.value, null]);
					});
				} else {
					slider.noUiSlider.disable(0);
				}
				if (inputTo.name) {
					inputTo.addEventListener('change', function () {
						slider.noUiSlider.set([null, this.value]);
					});
				} else {
					slider.noUiSlider.disable(1);
				}
				if (min) {
					inputs[0].value = min;
					fireEvent (inputs[0], "change");
				}
				if (max) {
					inputs[1].value = max;
					fireEvent(inputs[1], "change");
				}
            }
        });
    }
  /* ------------ UI Slider Range ------------ */
}

function fireEvent(element, event) {
  if ("createEvent" in document) {
    var evt = document.createEvent("HTMLEvents");
    evt.initEvent(event, false, true);
    element.dispatchEvent(evt);
  }
  else
    element.fireEvent("on" + event);
}