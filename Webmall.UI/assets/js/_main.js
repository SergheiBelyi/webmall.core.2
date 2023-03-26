'use strict';

document.addEventListener('DOMContentLoaded', function () {
  /* ------------ Tabs ------------ */
  document.querySelectorAll('.js-tabs').forEach(function (tabsContainer) {
    tabsContainer.querySelectorAll('.js-tabs-trigger').forEach(function (trigger, i) {
      trigger.addEventListener('click', function (e) {
        var target = e.target.closest('.js-tabs-trigger');
        e.preventDefault();
        if (target.classList.contains('is-active')) return;
        var hash = target.getAttribute('href');

        if (hash != '#') {
          window.location.hash = hash;
        }

        var root = target.closest('.js-tabs');
        switchTabClasses(root, i);
      });
    });
  });

  function switchTabClasses(root, i) {
    root.querySelectorAll('.js-tabs-trigger').forEach(function (trigger) {
      return trigger.classList.remove('is-active');
    });
    root.querySelectorAll('.js-tabs-pane').forEach(function (pane) {
      return pane.classList.remove('is-active');
    });
    root.querySelector(".tabs__item:nth-child(".concat(i + 1, ") .js-tabs-trigger")).classList.add('is-active');
    root.querySelector(".js-tabs-pane:nth-child(".concat(i + 1, ")")).classList.add('is-active');
  }
  /* Tabs Hash */


  var currentHash = window.location.hash;
  var hashTab = document.querySelector('.js-tabs-trigger[href="' + currentHash + '"]');

  if (hashTab) {
    var ev = new Event('click');
    hashTab.dispatchEvent(ev);
  }
  /* /Tabs Hash */

  /* Tabs Accordeon */


  document.addEventListener('click', function (e) {
    var toggle = e.target.closest('.js-tabs-accordion-toggle');
    if (!toggle) return;
    var parent = toggle.closest('.js-tabs-pane');

    if (parent.classList.contains('is-opened')) {
      parent.classList.remove('is-opened');
    } else {
      parent.classList.add('is-opened');
    }
  });
  /* /Tabs Accordeon */

  /* Go To Full Params Tab */

  var goToTabToggle = document.querySelector('[data-goto-tab]');

  if (goToTabToggle) {
    goToTabToggle.addEventListener('click', function (_ref) {
      var target = _ref.target;
      var hash = target.dataset.gotoTab;
      var hashTab = document.querySelector('.js-tabs-trigger[href="' + hash + '"]');
      var hashAccordion = document.querySelector(hash);

      if (hashTab) {
        var _ev = new Event('click');

        hashTab.dispatchEvent(_ev);
      }

      if (hashAccordion) {
        document.querySelectorAll('.js-tabs-pane').forEach(function (item) {
          return item.classList.remove('is-opened');
        });
        hashAccordion.parentNode.classList.add('is-opened');
      }
    });
  }
  /* Go To Full Params Tab */

  /* ------------ Tabs ------------ */

  /* ========================= JS Dropdown ========================= */


  document.addEventListener('click', function (e) {
    var dropdownToggle = e.target.closest('.js-dropdown-toggle');
    if (!dropdownToggle) return;
    var dropdownContainer = dropdownToggle.closest('.js-dropdown');

    if (!dropdownContainer.classList.contains('is-opened')) {
      document.querySelectorAll('.js-dropdown').forEach(function (item) {
        return item.classList.remove('is-opened');
      });
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

      handleClickOutside(dropdownContainer, function () {
        var openedDropdownParents = document.querySelectorAll('.js-dropdown.is-opened');
        openedDropdownParents.forEach(function (dropdownToggle) {
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

  var toggleNavbar = document.querySelector('.js-top-nav-trigger');
  /* Toggler Navbar */

  if (toggleNavbar) {
    toggleNavbar.addEventListener('click', function () {
      var body = document.body;
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

    var _navbarLinks = document.querySelectorAll('.top-nav a'); // let navbarLinks = document.querySelectorAll('.navbar .icon');


    _navbarLinks.forEach(function (item) {
      if (item.closest('li').querySelector('ul')) {
        item.classList.add('has-dropdown');
      }
    });

    var _dropdownToggles = document.querySelectorAll('.top-nav .has-dropdown');

    if (window.matchMedia('(max-width: 767px)').matches) {
      _dropdownToggles.forEach(function (item) {
        item.addEventListener('click', function (e) {
          item.closest('li').classList.toggle('is-opened');
          e.preventDefault();
        });
      });
    }
    /* /Toggles Deep Levels Inside */

  }
  /* ========================= /Navbar ========================= */

  /* ------------ Carousels ------------ */


  var mainCarousel = new Swiper('.js-main-carousel', {
    loop: true,
    slidesPerView: 1,
    // spaceBetween: 10,
    autoHeight: true,
    pagination: {
      el: '.js-main-carousel-pagination',
      clickable: true
    },
    autoplay: {
      delay: 5000
    },
    navigation: {
      prevEl: '.js-main-carousel-prev',
      nextEl: '.js-main-carousel-next'
    }
  });
  var sectionCarousels = document.querySelectorAll('.js-section-carousel');

  if (sectionCarousels) {
    sectionCarousels.forEach(initializeCarouselInstance);
  }

  var brandsCarousel = new Swiper('.js-brands-carousel', {
    slidesPerView: 1.67,
    spaceBetween: 20,
    grid: {
      rows: 2,
      fill: 'row'
    },
    pagination: {
      el: '.js-brands-carousel-pagination',
      clickable: true
    },
    navigation: {
      prevEl: '.js-brands-carousel-prev',
      nextEl: '.js-brands-carousel-next'
    },
    breakpoints: {
      480: {
        slidesPerView: 2.6,
        spaceBetween: 20
      },
      576: {
        slidesPerView: 3.6,
        spaceBetween: 20
      },
      768: {
        slidesPerView: 4.6,
        spaceBetween: 25
      },
      992: {
        slidesPerView: 5,
        spaceBetween: 30
      },
      1200: {
        slidesPerView: 6,
        spaceBetween: 30
      }
    }
  });
  var testimonialsCarousel = new Swiper('.js-testimonials-carousel', {
    slidesPerView: 1,
    spaceBetween: 15,
    loop: true,
    navigation: {
      prevEl: '.js-testimonials-carousel-prev',
      nextEl: '.js-testimonials-carousel-next'
    },
    pagination: {
      el: '.js-testimonials-carousel-pagination',
      clickable: true
    },
    breakpoints: {
      768: {
        slidesPerView: 2,
        spaceBetween: 25
      },
      992: {
        slidesPerView: 2,
        spaceBetween: 40
      },
      1200: {
        slidesPerView: 2,
        spaceBetween: 50
      }
    }
  });
  /* ------------ /Carousels ------------ */

  /* ------------ Modal Wins ------------ */

  var modalInstance = null;
  document.addEventListener('click', function (e) {
    var _target$dataset$close, _target$dataset$close2;

    var target = e.target.closest('[data-modal-win-trigger]');
    if (!target) return;
    var winId = target.dataset.modalWinTrigger;

    if (modalInstance) {
      modalInstance.close();
    }

    var _afterOpen = new Function(target.dataset.afterOpen);

    var _beforeClose = new Function(target.dataset.beforeClose);

    var closeOutside = target.dataset.closeOutside ? ((_target$dataset$close = target.dataset.closeOutside) === null || _target$dataset$close === void 0 ? void 0 : (_target$dataset$close2 = _target$dataset$close.toLowerCase) === null || _target$dataset$close2 === void 0 ? void 0 : _target$dataset$close2.call(_target$dataset$close)) === 'true' : true;
    modalInstance = new Modal({
      content: document.querySelector('[data-modal-win="' + winId + '"]'),
      className: "modal-win__main--".concat(winId),
      closeOutside: closeOutside,
      afterOpen: function afterOpen() {
        _afterOpen();

        document.body.style.paddingRight = scrollWidth() + 'px';
      },
      beforeClose: function beforeClose() {
        _beforeClose();

        document.body.style.paddingRight = '';
      }
    });
    modalInstance.open();
    e.preventDefault();
  });
  /* close btn */

  document.addEventListener('click', function (e) {
    var trigger = e.target.closest('.js-modal-close');
    if (!trigger) return;
    var closeBtn = trigger.closest('.modal-win').querySelector('.modal-win__close');

    if (closeBtn) {
      closeBtn.click();
    }
  });
  /* /close btn */

  /* ------------ /Modal Wins ------------ */

  /* ------------ LightGallery ------------ */

  document.querySelectorAll('.js-gallery').forEach(function (gallery) {
    lightGallery(gallery, {
      selector: 'a',
      download: false
    });
  });
  /* ------------ /LightGallery ------------ */

  /* ------------ Testimonials Section ------------ */

  document.addEventListener('click', function (_ref2) {
    var target = _ref2.target;
    var testimonialsTrigger = target.closest('.js-testimonials-trigger');
    if (!testimonialsTrigger) return;
    var body = document.body;
    body.classList.add('is-testimonials-opened');
    addOverlay();
    var testimonialsSection = document.querySelector('.testimonials-section');
    handleClickOutside(testimonialsSection, function () {
      body.classList.remove('is-testimonials-opened');
      removeOverlay();
    });
  });
  document.addEventListener('click', function (_ref3) {
    var target = _ref3.target;
    var testimonialsCloseButton = target.closest('.js-testimonials-close');
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
    content: function content(ref) {
      var template = ref.querySelector('[data-tippy-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-content');
    }
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
    content: function content(ref) {
      var template = ref.querySelector('[data-tippy-gray-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-gray-content');
    }
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
      positionFixed: true
    },
    content: function content(reference) {
      var parent = reference.parentNode;
      var template = parent.querySelector('[data-tooltip-content]');

      if (template) {
        return template.innerHTML;
      }
    }
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
    content: function content(ref) {
      var template = ref.querySelector('[data-tippy-interactive-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-interactive-content');
    }
  });
  tippy.delegate('body', {
    target: '[data-tippy-interactive-gray-content]',
    theme: 'is-gray',
    // trigger: 'click',
    interactive: true,
    appendTo: document.body,
    allowHTML: true,
    content: function content(ref) {
      var template = ref.querySelector('[data-tippy-interactive-gray-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-interactive-gray-content');
    }
  });
  tippy.delegate('body', {
    target: '[data-tippy-dropdown-content]',
    theme: 'light-border',
    trigger: 'click',
    interactive: true,
    appendTo: document.body,
    allowHTML: true,
    content: function content(ref) {
      var template = ref.querySelector('[data-tippy-dropdown-content-template]');

      if (template) {
        return template.innerHTML;
      }

      return ref.getAttribute('data-tippy-dropdown-content');
    }
  });
  /* ------------ Tippy JS ------------ */

  /* Choices Default */

  var choices = document.querySelectorAll('.js-select-default');
  choices.forEach(function (choice) {
    new Choices(choice, {
      delimiter: ',',
      searchEnabled: false,
      itemSelectText: '',
      shouldSort: false,
      placeholder: true
    });
  });
  /* /Choices Default */

  /* Autocomplete Type */

  var choicesAutocomplete = document.querySelectorAll('.js-select-autocomplete');
  choicesAutocomplete.forEach(function (choice) {
    new Choices(choice, {
      delimiter: ',',
      itemSelectText: '',
      noResultsText: 'Ничего не найдено!'
    });
  });
  /* /Autocomplete Type */

  initSliders();

  /* ------------ Filter ------------ */

  /* Show more */


  var filterMoreToggles = document.querySelectorAll('.filter__more-options');
  filterMoreToggles.forEach(function (item) {
    item.addEventListener('click', function (e) {
      var parent = e.target.closest('.filter__section');
      var textNode = this.children[0];

      if (parent.classList.contains('is-fields-on')) {
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

  document.addEventListener('pointerdown', function (e) {
    var toggler = e.target.closest('.filter__collapse');
    if (!toggler) return;
    e.preventDefault();
    var filter = document.querySelector('.filter');

    if (filter.classList.contains('is-collapsed')) {
      document.querySelectorAll('.filter__section').forEach(function (field) {
        field.classList.add('is-opened');
      });
      toggler.innerHTML = 'Свернуть все';
      filter.classList.remove('is-collapsed');
    } else {
      document.querySelectorAll('.is-fields-on').forEach(function (field) {
        field.classList.remove('is-fields-on');
        field.querySelector('.filter__more-options-amount').innerHTML = 'Показать все';
      });
      document.querySelectorAll('.filter__section').forEach(function (field) {
        field.classList.remove('is-opened');
      });
      toggler.innerHTML = 'Развернуть все';
      filter.classList.add('is-collapsed');
    }
  });
  /* Collapse all */

  /* Filter-Mobile */

  var filterToggle = document.querySelector('.filter-toggle');

  if (filterToggle) {
    filterToggle.addEventListener('click', function (e) {
      var body = document.body;

      if (!body.classList.contains('is-filter-opened')) {
        addOverlay();
        body.classList.add('is-filter-opened');
        body.style.paddingRight = scrollWidth() + 'px';
        setTimeout(function () {
          document.addEventListener('click', clickOutsideFilter);
        });
      }

      e.preventDefault();
    });
  }

  var filterClose = document.querySelector('.filter__close');

  if (filterClose) {
    filterClose.addEventListener('click', function (e) {
      var target = e.target.closest('.filter');
      if (!target) return;
      removeOverlay();
      document.body.classList.remove('is-filter-opened');
      document.body.style.paddingRight = '';
      document.removeEventListener('click', clickOutsideFilter);
    });
  }

  function clickOutsideFilter(e) {
    var target = e.target.closest('.filter');
    var datePicker = e.target.closest('.flatpickr-calendar');
    if (target || datePicker) return;
    removeOverlay();
    document.body.classList.remove('is-filter-opened');
    document.body.style.paddingRight = '';
    document.removeEventListener('click', clickOutsideFilter);
  }
  /* Filter-Mobile */

  /* Filter-Toggle-Section */


  document.addEventListener('click', function (e) {
    var target = e.target.closest('.filter__title');
    if (!target) return;
    target.closest('.filter__section').classList.toggle('is-opened');
    document.querySelectorAll('.filter').forEach(function (item) {
      item.classList.remove('is-collapsed');
    });
    document.querySelectorAll('.filter__collapse').forEach(function (item) {
      item.innerHTML = 'Свернуть все';
    });
  });
  /* Filter-Toggle-Section */

  /* ------------ Filter ------------ */

  /* ------------ Handle Click Outside ------------ */

  function handleClickOutside(elem, callback) {
    // const outsideClickListener = ev => {
    window.outsideClickListener = function (ev) {
      // if (!ev.target.closest(elem)) {
      if (!elem.contains(event.target) && isElemVisible(elem)) {
        if (typeof callback === 'function') {
          callback();
        }

        removeClickListener();
      }
    };

    var removeClickListener = function removeClickListener() {
      document.removeEventListener('click', outsideClickListener);
    };

    document.addEventListener('click', outsideClickListener);
  }
  /* ------------ /Handle Click Outside ------------ */

  /* ------------ Product-Main ------------ */


  var galleryThumbs = new Swiper('.js-thumbs-list', {
    slidesPerView: 3,
    spaceBetween: 15,
    watchSlidesVisibility: true,
    watchSlidesProgress: true,
    slideToClickedSlide: true,
    touchRatio: 0.2,
    breakpoints: {
      768: {
        direction: 'vertical',
        spaceBetween: 15
      },
      992: {
        direction: 'vertical',
        spaceBetween: 20
      }
    },
    navigation: {
      prevEl: '.js-thumbs-list-prev',
      nextEl: '.js-thumbs-list-next'
    }
  });
  var galleryMain = new Swiper('.js-promo-main', {
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
      swiper: galleryThumbs
    }
  });
  galleryMain.on('slideChangeTransitionStart', function () {
    galleryThumbs.slideTo(galleryMain.activeIndex);
  });
  galleryThumbs.on('transitionStart', function () {
    //if (galleryThumbs.isEnd) return;
    galleryMain.slideTo(galleryThumbs.activeIndex);
  });
  lightGallery(document.querySelector('.js-promo-main'), {
    selector: 'a',
    download: false
  });
  /* Drift Zoom */

  if (window.matchMedia('(min-width: 768px)').matches) {
    var initDriftZoom = function initDriftZoom(driftTriggerElement, driftPaneContainer) {
      if (!driftTriggerElement) return;
      driftInstance = new Drift(driftTriggerElement, {
        paneContainer: driftPaneContainer,
        hoverBoundingBox: true,
        zoomFactor: 3,
        inlinePane: false,
        handleTouch: false
      });
    };

    var driftPaneContainer = document.querySelector('.js-gallery-zoom-pane');
    var driftInstance = null;
    initDriftZoom(document.querySelector('.js-promo-main .swiper-slide-active img'), driftPaneContainer);
    galleryMain.on('slideChange', function () {
      setTimeout(function () {
        driftInstance.destroy();
        initDriftZoom(document.querySelector('.js-promo-main .swiper-slide-active img'), driftPaneContainer);
      });
    });
  }
  /* Drift Zoom */

  /* ------------ Product-Main ------------ */

  /* ------------ Is Element Visible ------------ */


  var isElemVisible = function isElemVisible(elem) {
    return !!elem && !!(elem.offsetWidth || elem.offsetHeight || elem.getClientRects().length);
  };
  /* ------------ /Is Element Visible ------------ */

  /* ------------ is touch helper ------------ */


  if ('ontouchstart' in window || navigator.msMaxTouchPoints) {
    document.documentElement.classList.add('is-touch');
  }
  /* ------------ /is touch helper ------------ */

  /* ------------ header height ------------ */


  var headerTopHeight = function headerTopHeight() {
    var doc = document.documentElement;
    var headerTop = document.querySelector('.header__top');
    if (!headerTop) return;
    var headerAvailableHeight = Math.max(parseInt(headerTop.offsetHeight) + headerTop.getBoundingClientRect().top, 0);
    doc.style.setProperty('--headerTopHeight', "".concat(headerAvailableHeight, "px"));
  };

  window.addEventListener('resize', debounce(headerTopHeight, 200));
  window.addEventListener('scroll', debounce(headerTopHeight, 200));
  headerTopHeight();
  /* ------------ /header height ------------ */

  /* ------------ iOS vh bug ------------ */

  var appHeight = function appHeight() {
    var doc = document.documentElement;
    var vh = window.innerHeight * 0.01;
    doc.style.setProperty('--vh', "".concat(vh, "px"));
  };

  window.addEventListener('resize', appHeight);
  appHeight();
  /* ------------ /iOS vh bug ------------ */

  /* -------- Accordions --------- */

  document.addEventListener('click', function (e) {
    var accordionTrigger = e.target.closest('.js-accordion-trigger');
    if (!accordionTrigger) return;
    e.preventDefault();
    var parent = accordionTrigger.closest('.js-accordion');
    var pane = parent.querySelector('.js-accordion-body');

    if (parent.classList.contains('is-active')) {
      slideUp(pane, 500, function () {
        parent.classList.remove('is-active');
      });
    } else {
      slideDown(pane, 500, function () {
        parent.classList.add('is-active');
      });
    }
  });
  /* -------- /Accordions --------- */

  /* -------- More Behaviour --------- */

  document.addEventListener('click', function (_ref4) {
    var target = _ref4.target;
    var moreBtn = target.closest('.js-more-btn');
    if (!moreBtn) return;
    var moreText = moreBtn.dataset.moreText ? moreBtn.dataset.moreText : 'Развернуть';
    var lessText = moreBtn.dataset.lessText ? moreBtn.dataset.lessText : 'Свернуть';
    var textStates = {
      more: moreText,
      less: lessText
    };
    showMore(moreBtn, textStates);
  });

  function showMore(btn, texts) {
    var parent = btn.closest('.js-more-parent');
    var btnText = btn.children[0] ? btn.children[0] : btn;

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


  document.querySelector('.footer').addEventListener('click', function (_ref5) {
    var target = _ref5.target;
    var footerCollapseTrigger = target.closest('.js-footer-collapse');
    if (!footerCollapseTrigger) return;
    footerCollapseTrigger.parentNode.classList.toggle('is-expanded');
  });
  /* -------- /Footer Collapse --------- */

  /* ------------ Counter ------------ */

  document.querySelectorAll('.counter').forEach(function (counter) {
    counter.addEventListener('click', function (_ref6) {
      var target = _ref6.target;
      var button = target.closest('[data-action]');
      if (!button) return;
      var mode = button.dataset.action;
      var input = counter.querySelector('input');
      var value = input.value;

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

  flatpickr.localize(flatpickr.l10ns.ru); // flatpickr.l10ns.default.firstDayOfWeek = 1;

  flatpickr('.js-date-picker', {
    dateFormat: 'd.m.Y',
    ariaDateFormat: 'd.m.Y',
    monthSelectorType: 'static',
    // disableMobile: true,
    prevArrow: '<svg viewBox="0 0 24 24" width="24" height="24"><path d="M14.411 19.021l-6.288-6.287a1.013 1.013 0 010-1.467l6.288-6.288a1.013 1.013 0 011.467 0 1.013 1.013 0 010 1.467L10.324 12l5.554 5.554a1.013 1.013 0 010 1.467 1.013 1.013 0 01-1.467 0z"/></svg>',
    nextArrow: '<svg viewBox="0 0 24 24" width="24" height="24"><path d="M9.591 19.021l6.286-6.287a1.013 1.013 0 000-1.469L9.591 4.979a1.013 1.013 0 00-1.467 0 1.013 1.013 0 000 1.467L13.676 12l-5.554 5.554a1.038 1.038 0 101.469 1.467z"/></svg>'
  });
  /* ------------ /Date Pickers ------------ */

  /* -------- Light Galleries --------- */

  document.querySelectorAll('.js-item-gallery').forEach(function (item) {
    lightGallery(item, {
      selector: 'this',
      download: false
    });
  });
  /* -------- /Light Galleries --------- */

  /* -------- Spec Catalog Table Collapse -------- */

  document.addEventListener('change', function (_ref7) {
    var target = _ref7.target;
    var toggleAllSpecs = target.closest('.js-spec-params-all-trigger');
    if (!toggleAllSpecs) return;
    var specTableParams = document.querySelectorAll('.spec-table-params');
    specTableParams.forEach(function (specTableParam) {
      var specButtonText = specTableParam.querySelector('.btn__text');

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
  document.addEventListener('click', function (_ref8) {
    var target = _ref8.target;
    var specParamsTrigger = target.closest('.js-spec-params-trigger');
    if (!specParamsTrigger) return;
    document.querySelectorAll('.js-spec-params-all-trigger').forEach(function (checkbox) {
      return checkbox.checked = false;
    });
    var parent = specParamsTrigger.parentNode;
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

  document.addEventListener('click', function (e) {
    var priceFilterCheckbox = e.target.closest('.js-col-switch');
    if (!priceFilterCheckbox) return;
    var value = priceFilterCheckbox.value;
    var parent = document.querySelector('.data-table');
    var buyCols = document.querySelectorAll('[data-col-buy]');
    var sellCols = document.querySelectorAll('[data-col-sell]');

    switch (value) {
      case 'buy':
        buyCols.forEach(function (col) {
          return col.hidden = false;
        });
        sellCols.forEach(function (col) {
          return col.hidden = true;
        });
        parent.classList.add('has-buy-col');
        parent.classList.remove('has-sell-col');
        break;

      case 'sell':
        buyCols.forEach(function (col) {
          return col.hidden = true;
        });
        sellCols.forEach(function (col) {
          return col.hidden = false;
        });
        parent.classList.add('has-sell-col');
        parent.classList.remove('has-buy-col');
        break;

      case 'both':
        buyCols.forEach(function (col) {
          return col.hidden = false;
        });
        sellCols.forEach(function (col) {
          return col.hidden = false;
        });
        parent.classList.remove('has-sell-col', 'has-buy-col');
        break;
    }
  });
  /* Product Detail Filter Checkbox */

  /* toggle all checkboxes */

  var checkAllControls = document.querySelectorAll('.js-checked-all-trigger');
  checkAllControls.forEach(function (checkAllControl) {
    checkAllControl.addEventListener('change', function (_ref9) {
      var target = _ref9.target;
      var parent = target.closest('.js-checked-all');
      var checkboxes = parent.querySelectorAll('.js-checked-all-item, .js-checked-all-trigger');
      checkboxes.forEach(function (checkbox) {
        return checkbox.checked = target.checked;
      });
    });
  });
  document.addEventListener('change', function (_ref10) {
    var target = _ref10.target;
    if (!target.classList.contains('js-checked-all-item')) return;
    var parent = target.closest('.js-checked-all');

    while (parent) {
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

  var checkboxSubmitStatus = document.querySelector('.js-privacy-state-trigger');

  if (checkboxSubmitStatus) {
    checkboxSubmitStatus.addEventListener('change', function (_ref11) {
      var currentTarget = _ref11.currentTarget;
      var submitBtn = document.querySelector('.js-privacy-state-btn');
      submitBtn.disabled = !currentTarget.checked;
    });
  }
  /* /privacy btn state */

  /* sidebar-trigger */


  var sidebarTrigger = document.querySelector('.js-sidebar-trigger');

  if (sidebarTrigger) {
    sidebarTrigger.addEventListener('click', function (e) {
      var parent = e.target.closest('.primary');
      if (!parent) return;
      parent.classList.toggle('is-full');
    });
  }
  /* /sidebar-trigger */

  /* ============== js-more-trigger ============== */


  document.addEventListener('click', function (_ref12) {
    var target = _ref12.target;
    var moreTrigger = target.closest('.js-more-trigger');
    if (!moreTrigger) return;
    var parent = moreTrigger.parentNode;
    var moreTriggerTextNode = moreTrigger.querySelector('span') ? moreTrigger.querySelector('span') : moreTrigger;

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

  var modeTrigger = document.querySelector('.js-mode-trigger');

  if (modeTrigger) {
    modeTrigger.addEventListener('change', function (_ref13) {
      var target = _ref13.target;
      var tableMode = target;
      var parent = document.querySelector('.stock-area');

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


  document.addEventListener('click', function (_ref14) {
    var target = _ref14.target;
    var innerMobTableBtn = target.closest('.js-inner-table-trigger');
    if (!innerMobTableBtn) return;
    var parent = innerMobTableBtn.closest('.js-inner-table');
    var btns = parent.querySelectorAll('.js-inner-table-trigger');

    if (parent.classList.contains('is-active')) {
      parent.classList.remove('is-active');
      btns.forEach(function (btn) {
        return btn.querySelector('span').textContent = 'Показать позиции заказа';
      });
    } else {
      parent.classList.add('is-active');
      btns.forEach(function (btn) {
        return btn.querySelector('span').textContent = 'Скрыть позиции заказа';
      });
    }
  });
  /* ============== /js inner trigger ============== */

  /* footer popup window */

  var footerPopupTrigger = document.querySelector('.js-callback-popup-trigger');

  if (footerPopupTrigger) {
    footerPopupTrigger.addEventListener('click', function (e) {
      e.preventDefault();
      var body = document.body;
      var closeWinTrigger = document.querySelector('.footer-popup__close');
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
    var body = document.body;
    body.classList.remove('is-popup-opened');
    body.style.paddingRight = '';
    removeOverlay();
    document.removeEventListener('mousedown', footerPopupCheckClickOutside);
  }

  function footerPopupCheckClickOutside(e) {
    var target = e.target.closest('.footer-popup');
    if (target) return;
    closePopupWin();
  }
  /* /footer popup window */


  document.addEventListener('click', function (e) {
    var regionsTrigger = e.target.closest('.js-regions-trigger');
    if (!regionsTrigger) return;
    document.body.classList.remove('is-main-nav-opened', 'is-navbar-opened', 'is-modal-contacts-active', 'is-mob-search-opened');
    document.body.classList.add('is-regions-opened');
  });
  document.addEventListener('click', function (e) {
    var regionsTriggerClose = e.target.closest('.mob-regions__close');
    if (!regionsTriggerClose) return;
    document.body.classList.remove('is-regions-opened');
  });
  document.addEventListener('click', function (e) {
    var mobContactsTrigger = e.target.closest('.js-mob-contacts');
    if (!mobContactsTrigger) return;
    e.preventDefault();
    document.body.classList.add('is-modal-contacts-active');
    addOverlay();
  });
  document.addEventListener('click', function (e) {
    var mobContactsClose = e.target.closest('.header-mob-contacts__close');
    if (!mobContactsClose) return;
    e.preventDefault();
    document.body.classList.remove('is-modal-contacts-active');
    removeOverlay();
  });
  var navTrigger = document.querySelector('.navigation-trigger');

  if (navTrigger) {
    navTrigger.addEventListener('click', function () {
      document.body.classList.toggle('is-main-nav-opened');
    });
  }
  /* --- STICKY HEADER --- */


  var headerSticky = document.querySelector('.header-meta-area');
  var stickyOffset = headerSticky.offsetTop;
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


  document.addEventListener('click', function (e) {
    var target = e.target.closest('.mob-nav__link.has-dropdown');
    if (!target) return;
    e.preventDefault();
    target.parentNode.classList.toggle('is-active');
  });
  /* /header-mob-nav */

  /* ------------ Catalog-Navbar ------------ */

  document.querySelector('.catalog-nav-toggle').addEventListener('click', function () {
    var body = document.body;

    if (!body.classList.contains('is-navbar-opened')) {
      body.classList.add('is-navbar-opened');
      body.style.paddingRight = scrollWidth() + 'px'; // addOverlay();

      setTimeout(function () {
        document.addEventListener('click', clickOutsideNavbar);
      });
    }
  });

  function clickOutsideNavbar(e) {
    var target = e.target.closest('.main-nav');
    if (target) return;
    document.body.classList.remove('is-navbar-opened');
    document.body.style.paddingRight = ''; // removeOverlay();

    document.removeEventListener('click', clickOutsideNavbar);
  }
  /* Toggles Inside */
  // create toggles


  var navbarLinks = document.querySelectorAll('.main-nav__container .main-nav__link');
  navbarLinks.forEach(function (item) {
    if (item.closest('li').querySelector('ul')) {
      item.classList.add('has-dropdown');
    }
  });
  var dropdownToggles = document.querySelectorAll('.main-nav .has-dropdown');
  dropdownToggles.forEach(function (item) {
    item.addEventListener('click', function (e) {
      item.closest('li').classList.toggle('is-opened');
      e.preventDefault();
    });
  });
  /* Toggles Inside */

  /* ------------ Catalog-Navbar ------------ */

  /* ------------ Mob Nav ------------ */

  document.querySelector('.mob-nav').addEventListener('click', function (e) {
    var target = e.target.closest('.mob-nav__link');
    if (!target) return;
    if (!target.closest('.has-dropdown')) return;
    e.preventDefault();
    target.parentNode.classList.toggle('is-opened');
  });
  /* ------------ Mob Nav ------------ */

  /* ------------ Authorize-Dropdown ------------ */

  if (document.querySelector('.authorize__link--login')) {
    var clickOutsideAuthorize = function clickOutsideAuthorize(e) {
      var target = e.target.closest('.authorize__dropdown');
      if (target) return;
      document.querySelector('.authorize').classList.remove('is-dropdown-opened');
      document.removeEventListener('click', clickOutsideAuthorize);
    };

    document.querySelector('.authorize__link--login').addEventListener('click', function (e) {
      var parent = this.closest('.authorize');

      if (!parent.classList.contains('is-dropdown-opened')) {
        parent.classList.add('is-dropdown-opened');
        setTimeout(function () {
          document.addEventListener('click', clickOutsideAuthorize);
        });
      }

      e.preventDefault();
    });
  }
  /* ------------ Authorize-Dropdown ------------ */


  var searchTypeSelect = new Choices('.js-select-search', {
    delimiter: ',',
    searchEnabled: false,
    itemSelectText: '',
    shouldSort: false
  });
  searchTypeSelect.passedElement.element.addEventListener('change', function (e) {
    var value = e.target.value;
    var searchInput = document.querySelector('.search-form__input');

    switch (value) {
      case 'articul':
        searchInput.placeholder = 'Номер артикула';
        break;

      case 'title':
        searchInput.placeholder = 'Наименование';
        break;

      case 'vin':
        searchInput.placeholder = 'VIN';
        break;
    }
  });
  document.querySelector('.section-nav').addEventListener('mouseenter', function (e) {
    searchTypeSelect.hideDropdown();
  });
  /* informer */

  document.addEventListener('click', function (e) {
    var target = e.target.closest('.top-informer__close');
    if (!target) return;
    target.closest('.top-informer').hidden = true;
    stickyOffset = headerSticky.offsetTop;
  });
  /* /informer */

  /* --- Banner --- */

  if (document.querySelector('.header-banner__close')) {
    var bannerToggles = document.querySelectorAll('.header-banner__close');
    bannerToggles.forEach(function (bannerToggle) {
      bannerToggle.addEventListener('click', function (e) {
        e.target.closest('.header-banner').hidden = true;
        e.preventDefault();
        stickyOffset = headerSticky.offsetTop;
      });
    });
  }
  /* --- Banner --- */

  /*  ============== Tree Nav ============== */
  // create toggles


  var treeNavLinks = document.querySelectorAll('.tree-nav a'); // const treeNavLinks = document.querySelectorAll('.navbar .icon');

  treeNavLinks.forEach(function (item) {
    if (item.closest('li').querySelector('ul')) {
      item.classList.add('has-dropdown');
    }
  });
  var treeNavToggles = document.querySelectorAll('.tree-nav .has-dropdown');
  treeNavToggles.forEach(function (item) {
    item.addEventListener('click', function (e) {
      item.closest('li').classList.toggle('is-opened');
      e.preventDefault();
    });
  });
  /* ============== Tree Nav ============== */
});
/* ------------ Helpers ------------ */

function scrollWidth() {
  var div = document.createElement('div');
  var body = document.body;
  div.style.overflowY = 'scroll';
  div.style.width = '50px';
  div.style.height = '50px';
  div.style.visibility = 'hidden';
  body.appendChild(div);
  var scrollWidth = div.offsetWidth - div.clientWidth;
  body.removeChild(div);
  return scrollWidth;
}

function addOverlay() {
  var overlay = document.createElement('div');
  overlay.className = 'overlay';
  document.body.appendChild(overlay);
}

function removeOverlay() {
  var overlay = document.querySelector('.overlay');
  if (overlay) overlay.remove();
}

function debounce(func, wait, immediate) {
  var timeout;
  return function () {
    var context = this,
        args = arguments;

    var later = function later() {
      timeout = null;
      if (!immediate) func.apply(context, args);
    };

    var callNow = immediate && !timeout;
    clearTimeout(timeout);
    timeout = setTimeout(later, wait);
    if (callNow) func.apply(context, args);
  };
}

;

function throttle(callback, limit) {
  var waiting = false; // Initially, we're not waiting

  return function () {
    // We return a throttled function
    if (!waiting) {
      // If we're not waiting
      callback.apply(this, arguments); // Execute users function

      waiting = true; // Prevent future invocations

      setTimeout(function () {
        // After a period of time
        waiting = false; // And allow future invocations
      }, limit);
    }
  };
}

function slideUp(target) {
  var duration = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : 500;
  var callback = arguments.length > 2 ? arguments[2] : undefined;

  if (!target.classList.contains('in-progress')) {
    target.classList.add('in-progress');
    target.style.transitionProperty = 'height, margin, padding';
    target.style.transitionDuration = duration + 'ms';
    target.style.height = "".concat(target.offsetHeight, "px");
    target.offsetHeight;
    target.style.overflow = 'hidden';
    target.style.height = 0;
    target.style.paddingTop = 0;
    target.style.paddingBottom = 0;
    target.style.marginTop = 0;
    target.style.marginBottom = 0;
    window.setTimeout(function () {
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

function slideDown(target) {
  var duration = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : 500;
  var callback = arguments.length > 2 ? arguments[2] : undefined;

  if (!target.classList.contains('in-progress')) {
    target.classList.add('in-progress');
    target.hidden = target.hidden ? false : null;
    var height = target.offsetHeight;
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
    window.setTimeout(function () {
      target.style.removeProperty('height');
      target.style.removeProperty('overflow');
      target.style.removeProperty('transition-duration');
      target.style.removeProperty('transition-property');
      target.classList.remove('in-progress');
      callback();
    }, duration);
  }
}

function slideToggle(target) {
  var duration = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : 500;

  if (target.hidden) {
    return slideDown(target, duration);
  } else {
    return slideUp(target, duration);
  }
}

function initializeCarouselInstance(instance) {
  var parentSection = instance.parentNode;
  var slidesLength = instance.querySelectorAll('.swiper-slide').length;
  var pagination = parentSection.querySelector('.js-section-carousel-pagination');
  var prev = parentSection.querySelector('.js-section-carousel-prev');
  var next = parentSection.querySelector('.js-section-carousel-next');
  var isLoop = slidesLength > 5;
  new Swiper(instance, {
    loop: isLoop,
    slidesPerView: 1,
    spaceBetween: 10,
    watchSlidesProgress: true,
    pagination: {
      el: pagination,
      clickable: true
    },
    navigation: {
      prevEl: prev,
      nextEl: next
    },
    breakpoints: {
      440: {
        slidesPerView: 2,
        spaceBetween: 10
      },
      576: {
        slidesPerView: 3,
        spaceBetween: 10
      },
      768: {
        slidesPerView: 4,
        spaceBetween: 20
      },
      992: {
        slidesPerView: 5,
        spaceBetween: 20
      }
    }
  });
}

function initSliders() {
    /* ------------ UI Slider Range ------------ */
    var sliders = document.querySelectorAll('.js-range-slider');

    if (sliders) {
        sliders.forEach(function (slider) {
            var dataFrom = parseInt(slider.dataset.from) || 0;
            var dataTo = parseInt(slider.dataset.to) || 65000;
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


            noUiSlider.create(slider, {
                start: [dataFrom, dataTo],
                connect: true,
                // tooltips: true,
                step: rangeStep,
                range: {
                    min: dataFrom,
                    max: dataTo
                },
                format: sliderFormat
            }); // sync inputs to the range

            if (inputFrom && inputTo) {
                slider.noUiSlider.on('update', function (values, handle) {
                    inputs[handle].value = values[handle];
                });
                slider.noUiSlider.on('change', function (values, handle) {
                    inputs[handle].value = values[handle];
                });
                inputFrom.addEventListener('change', function () {
                    slider.noUiSlider.set([this.value, null]);
                });
                inputTo.addEventListener('change', function () {
                    slider.noUiSlider.set([null, this.value]);
                });
            }
        });
    }
  /* ------------ UI Slider Range ------------ */
}