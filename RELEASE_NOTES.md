#### 1.0.0 - 2025-12-09
* Major update for react-toastify v11.x
* Added new ToastContainer props: pauseOnFocusLoss, stacked, containerId, draggablePercent, draggableDirection, className, style, toastClassName, bodyClassName, progressClassName, closeButton, icon, role
* Added new toast props: pauseOnFocusLoss, toastId, delay, containerId, className, style, bodyClassName, progressClassName, closeButton, icon, isLoading, data, role, onClick, onOpen, onClose, render, toastType
* Added new ToastApi methods: loading, dismiss, dismissById, isActive, update, updateWithContent, updateWithString, done, clearWaitingQueue, play, pause, promise
* Added new types: DraggableDirection, ToastType
* Added simple string and ReactElement toast variants (successString, errorString, infoString, warningString, warnString, defaultString, successSimple, errorSimple, etc.)
* Toast functions now return ToastId for tracking
* Added loadingToast Elmish command
* Updated documentation and examples

#### 0.1.7 - 2025-04-26
* Use newest Fable.Elmish
#### 0.1.6 - 2025-04-16
* Downgrade Fable.Elmish
#### 0.1.5 - 2025-04-16
* Fix repro link
#### 0.1.4 - 2025-04-16
* Downgrade Fable.Elmish
#### 0.1.3 - 2025-04-16
* No tailwind
#### 0.1.2 - 2025-04-16
* Add Custom Component
#### 0.1.1 - 2025-04-15
* More types
#### 0.1.0 - 2025-04-15
* Initial release
